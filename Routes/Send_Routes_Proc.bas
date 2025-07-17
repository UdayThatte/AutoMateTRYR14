Attribute VB_Name = "Send_Routes_Proc"

Dim Stg_Info(200) As String
Dim Fare_Info(20000) As String 'n(n-1)/2
Dim Stg_Info_mName(200) As String
Dim Stg_Info_Id(200) As String

Dim line_in_rut As Integer
Dim no_of_ruts As Integer
Dim Crnt_Rut_type As String 'TT or SS
Dim Crnt_Rut_Str As String
Dim Prv_Rut_Str As String
Dim Crnt_Rut_No As Integer 'currently processed route no
Dim Crnt_No_Of_Stages As Integer  'in current processing of route
Dim Off_in_rut_tbl_file As Long 'this is actually offset in file
Dim Crnt_Start_Stage As Integer

Dim Rout_Summ_rec As Rout_Summary '64 byte
'Dim Stg_Summ_rec As Stage_Summary  '48 bytes


Public Sub Send_Routes_to_ETM()
Dim ok_to_send As Boolean
Dim summary_rec_to_snd As String * size_of_route_summary '64
Dim rut_tbl_dat_to_snd As String * 48
Dim size_of_file As Long
Dim addr As Long
Dim block As Long
Dim read_byte As Byte

'if response file is present delete
If Dir(Apppath + File_Rcvd) <> "" Then Kill (Apppath + File_Rcvd)

 ok_to_send = Check_if_mc_data_is_clear 'commu fail or no of tckts non zero
  If ok_to_send = False Then
    write_out_file (Err_Time_out + "- Ticket Data is Present")
    Exit Sub
  End If

 ok_to_send = check_if_waybil_present 'true if present
  If ok_to_send = True Then
    write_out_file (Err_Time_out + " - WayBill is Present")
    Exit Sub
  End If

 If Dir(Apppath + File_Routes) = "" Then
    write_out_file (Err_Time_out + "- NO FILE")
    Exit Sub
 End If
'' if file present go for compilation
    ok_to_send = Compile_Routes 'returns true if done false for error
 ''after compilation two files are ready for sending
  ''rut_summ.cod summary file & rut_tbl.cod all stage table entries one after another
 If ok_to_send = False Then Exit Sub
 
 ''rut_summ is always in multiple of 64 bytes
 ''rut_tbl.cod can be of odd bytes in length
 'now make crnt route no . crnt rout idx  crnt trip no = 0 AND also no od route
'
    Handheld.send_data_to_long_eeprom Chr$(0) + Chr$(0), Adr_Crnt_Rut_no
    Handheld.send_data_to_long_eeprom Chr$(0) + Chr$(0), Adr_crnt_Rut_Idx
    Handheld.send_data_to_long_eeprom Chr$(0) + Chr$(1), Adr_Crnt_Trip_No
    Handheld.send_data_to_long_eeprom Chr$(0) + Chr$(0), Adr_No_Of_Routes

    If Handheld.Error_Comm = True Then
        write_Err_In_file Handheld.Error_Code, ""
        Exit Sub
    End If

''start sending route summary
    Open Apppath + File_Rut_Sum_Cod For Binary Access Read As #2   'open route summary file to send
         Seek #2, 1
         addr = Adr_Strt_Rout_summ
         For n = 1 To no_of_ruts
            Get #2, , summary_rec_to_snd
            
                Handheld.send_data_to_long_eeprom summary_rec_to_snd, addr
                If Handheld.Error_Comm = True Then
                    Close #2
                    Kill Apppath + File_Rut_Sum_Cod
                    Close #3 'also close rut tbl file and delete
                    Kill Apppath + File_Rut_Tbl_Cod
                    write_Err_In_file Handheld.Error_Code, ""
                    Exit Sub
                End If
           addr = addr + Len(summary_rec_to_snd)
         Next n
    Close #2
    Kill Apppath + File_Rut_Sum_Cod
'''now send fare tbl file (route tbl file)

    Open Apppath + File_Rut_Tbl_Cod For Binary Access Read As #3    'open route summary file to send
        
     size_of_file = LOF(3) 'this gives size of file in bytes
     'at a time only 48 bytes are sent if the file is not in multiple then
     'last part will remain short check for even no of bytes
     Seek #3, 1  'start with first position
     addr = Adr_strt_Rout_Tbl
        block = 0
        'n = 0
        Do
            Get #3, , rut_tbl_dat_to_snd
            'n = n + 1   'no of blocks sent
            block = block + 48
            Handheld.send_data_to_long_eeprom rut_tbl_dat_to_snd, addr
                If Handheld.Error_Comm = True Then
                    Close #3
                    Kill Apppath + File_Rut_Tbl_Cod
                    write_Err_In_file Handheld.Error_Code, ""
                    Exit Sub
                End If
         addr = addr + 48
        Loop While block + 48 < size_of_file
'find out if any bytes pending
        tmp_str = ""
        If block <> size_of_file Then  ''that means few bytes are pending
           bytes_to_send = size_of_file - block
            For n = 1 To bytes_to_send
                Get #3, , read_byte
                tmp_str = tmp_str + Chr$(read_byte)
            Next n
        ''now if the read bytes are odd then add one zero to it
          If (bytes_to_send Mod 2) > 0 Then
            tmp_str = tmp_str + Chr$(0)
          End If
          rut_tbl_dat_to_snd = tmp_str
          Handheld.send_data_to_long_eeprom Mid$(rut_tbl_dat_to_snd, 1, Len(tmp_str)), addr
               If Handheld.Error_Comm = True Then
                    'write_out_file (Err_Time_out)
                    Close #3
                    Kill Apppath + File_Rut_Tbl_Cod
                    write_Err_In_file Handheld.Error_Code, ""
                    Exit Sub
               End If

         End If  'for sending pending bytes loop ends here
    Close #3
    Kill Apppath + File_Rut_Tbl_Cod
 '
    Handheld.send_data_to_long_eeprom Chr$(no_of_ruts \ 256) + Chr$(no_of_ruts And &HFF), Adr_No_Of_Routes
                  If Handheld.Error_Comm = True Then
                    'write_out_file (Err_Time_out)
                    If Dir(Apppath + File_Rut_Tbl_Cod) <> "" Then Kill Apppath + File_Rut_Tbl_Cod
                    If Dir(Apppath + File_Rut_Sum_Cod) <> "" Then Kill Apppath + File_Rut_Sum_Cod
                    write_Err_In_file Handheld.Error_Code, ""
                    Exit Sub
                  End If
    'write_out_file ("$Done-Transferred " + CStr(no_of_ruts) + " Routes")
    'Handheld.send_str_to_unit Chr$(3), 6 'end comm mode command to etm
    
    If Dir(Apppath + File_Rut_Tbl_Cod) <> "" Then Kill Apppath + File_Rut_Tbl_Cod
    If Dir(Apppath + File_Rut_Sum_Cod) <> "" Then Kill Apppath + File_Rut_Sum_Cod

Select Case Mc_Type
    Case Is = "ETM8BIT"
        Handheld.send_str_to_unit Chr$(3), 6 'end comm mode command to etm
    Case Is = "ETMARM"
        Handheld.Set_Activity_Code Chr$(Act_RouteLoad), 6 'end comm mode command to etm
End Select

If Handheld.Error_Comm = True Then
    write_Err_In_file Handheld.Error_Code, ""
Else
    write_Err_In_file Handheld.Error_Code, "$Done-Transferred " + CStr(no_of_ruts) + " Routes"
End If
    
End Sub
Private Function Compile_Routes()
Dim tmp_str As String
 Dim done As Boolean
 ''Dim no_of_ruts As Integer
 Dim found_rut As Boolean
 ''Dim line_in_rut As Integer
 Dim first_line As String
 
 If Dir(Apppath + File_Rut_Sum_Cod) <> "" Then Kill Apppath + File_Rut_Sum_Cod
 If Dir(Apppath + File_Rut_Tbl_Cod) <> "" Then Kill Apppath + File_Rut_Tbl_Cod
 
 Compile_Routes = True
 Off_in_rut_tbl_file = 0
 
 done = False
 no_of_ruts = 0
'refer to route_rules.txt
    Open Apppath + File_Routes For Input As #1  'open routes file
        Open Apppath + File_Rut_Sum_Cod For Binary Access Write As #2   'open route summary file to send
         Seek #2, 1
        Open Apppath + File_Rut_Tbl_Cod For Binary Access Write As #3   'open route Tbl file to send
         Seek #3, 1
    Do
        
        Do
        
        Line Input #1, tmp_str
        
        If (Mid$(tmp_str, 1, 2) = "$R") Then
            found_rut = True
            Exit Do
        End If
            If found_rut = True Then
                found_rut = False  'this is the first line of route
                            'process first line and skip loop
                If (Len(tmp_str) <> 58) And (Len(tmp_str) <> 62) Then 'for Start Stage 4 added
                    write_out_file (Err_Time_out + "-Route Master Not Proper for Route No." + CStr(Crnt_Rut_No))
                    Compile_Routes = False
                    done = True
                    Exit Do
                End If
                'this line is ok first line
                first_line = tmp_str
                process_first_rut_line tmp_str, 2 'this prepares rout summary record file no
                line_in_rut = 1
                Exit Do  'this skips the processed first line
            End If
        'if it comes here it is stage line of the found route
        'now decide if route is Triangular or Straigh depending upon that
        'length and processing will change
           If Rout_Summ_rec.Tbl_typ = "TT" Then
                If (Len(tmp_str) <> 24 + (line_in_rut * 8)) And (Len(tmp_str) <> 24 + (line_in_rut * 8) + 17) And (Len(tmp_str) <> 24 + (line_in_rut * 8) + 17 + 7) Then 'see route_rules
                    write_out_file (Err_Time_out + "-Route Master Not Proper for Route No." + CStr(Crnt_Rut_No))
                    Compile_Routes = False
                    done = True
                    Exit Do
                End If
                process_stage_line_triangular tmp_str, 3 'this saves rout tbl entry
           Else  'it is straight type
                If (Len(tmp_str) <> 32) And (Len(tmp_str) <> 32 + 17) And (Len(tmp_str) <> 32 + 17 + 7) Then
                    write_out_file (Err_Time_out + "-Route Master Not Proper for Route No." + CStr(Crnt_Rut_No))
                    Compile_Routes = False
                    done = True
                    Exit Do
                End If
                process_stage_line_straight tmp_str, 3 'this saves rout for straight type
           
           
           End If
                     
                
                line_in_rut = line_in_rut + 1
        'Loop While Not EOF(1) And Not (Mid$(tmp_str, 1, 2) = "$R")
        Loop While Not EOF(1)
''found new route start point or file end
    If EOF(1) Then
    done = True 'to break the do loop
    ''perform check for last route processed there may be carriage return for last route
            If line_in_rut <> Crnt_No_Of_Stages + 1 Then
                    write_out_file (Err_Time_out + "-Route Master Not Proper for Route No." + CStr(Crnt_Rut_No))
                    Compile_Routes = False
                    Exit Do
            Else  'saving of last route tbl data is to be performed here
                If Rout_Summ_rec.Tbl_typ = "TT" Then
                    Save_Rout_Tbl_Data_triangular 3  'passes file no
                Else
                    Save_Rout_Tbl_Data_straight 3  'passes file no
                End If
            End If
    End If
    
    If found_rut = True Then
     Prv_Rut_Str = Crnt_Rut_Str
     Crnt_Rut_Str = Mid$(tmp_str, 3, 3)
     Crnt_Rut_No = Val(Mid$(tmp_str, 3, 3))
     no_of_ruts = no_of_ruts + 1
     ''perform check for last route processed when II route is found
     ''when II route found first route data is ready and stored
        If no_of_ruts > 1 Then
                m = 0
                ''no of line in a defined route  = no of stages+1
                'this 1 is for route sy=ummary
                If line_in_rut <> Crnt_No_Of_Stages + 1 Then
                            write_out_file (Err_Time_out + "-Route Master Not Proper for Route No." + CStr(Prv_Rut_Str))
                            Compile_Routes = False
                            done = True
                            Exit Do
                Else ''this route tbl data is to be saved
                    If Rout_Summ_rec.Tbl_typ = "TT" Then
                        Save_Rout_Tbl_Data_triangular 3  'passes file no
                    Else
                        Save_Rout_Tbl_Data_straight 3  'passes file no
                    End If
                End If
        End If
    End If  'route start  found ends here
    
    Loop While Not done
    
    Close #1
    Close #2
    Close #3
    
    If Compile_Routes = False Then
        Kill Apppath + File_Rut_Sum_Cod
        Kill Apppath + File_Rut_Tbl_Cod
    End If



End Function
Private Sub Save_Rout_Tbl_Data_straight(file_no As Integer)
Dim filt_str As Long
Dim first As Byte
Dim stg_rec_to_store As Stg_Rec
'first store stage data

   For m = 1 To Crnt_No_Of_Stages
        tmp_str = Stg_Info(m)
                
        'Str_to_BCD "0" + Mid$(tmp_str, 1, 3), filt_str
        Str_to_BCD Format(CStr(Crnt_Start_Stage), "0000"), filt_str
        Crnt_Start_Stage = Crnt_Start_Stage + 1
        
        stg_rec_to_store.Stg_no = Chr$((filt_str And &HFF00) \ 256) + Chr$(filt_str And &HFF)
        stg_rec_to_store.Stg_Cod = Mid$(tmp_str, 5, 3) 'code
        stg_rec_to_store.Stg_Name = Mid$(tmp_str, 9, 11) 'name
        Str_to_BCD Mid$(tmp_str, 21, 4), filt_str
        stg_rec_to_store.Stg_dist = Chr$((filt_str And &HFF00) \ 256) + Chr$(filt_str And &HFF)
        
        stg_rec_to_store.Stg_mName = Stg_Info_mName(m)
        
        Str_to_BCD ("00" + Mid$(Stg_Info_Id(m), 1, 2)), filt_str
        first = CByte(filt_str And &HFF)
        Str_to_BCD Mid$(Stg_Info_Id(m), 3, 4), filt_str
        stg_rec_to_store.Stg_Id = Chr$(first) + Chr$((filt_str And &HFF00) \ 256) + Chr$(filt_str And &HFF)
        
        Put #file_no, , stg_rec_to_store
         
   Next m
   
   
   
   For m = 2 To Crnt_No_Of_Stages
        tmp_str = Fare_Info(m)
        Str_to_BCD Mid$(tmp_str, 1, 4), filt_str  'Rs.
        Put #file_no, , Chr$((filt_str And &HFF00) \ 256) + Chr$(filt_str And &HFF)
        Str_to_BCD "00" + Mid$(tmp_str, 6, 2), filt_str 'paise
        Put #file_no, , Chr$(filt_str And &HFF)
   Next m
   
   
   
   
   Off_in_rut_tbl_file = Off_in_rut_tbl_file + (Crnt_No_Of_Stages * Size_Of_Stg_Rec) + ((Crnt_No_Of_Stages - 1) * 3)
   
End Sub
Private Sub Save_Rout_Tbl_Data_triangular(file_no As Integer)
'using stg_info and fare_info arrays save into file at current position
Dim filt_str As Long
Dim first As Byte
Dim stg_rec_to_store As Stg_Rec
'first store stage data

   For m = 1 To Crnt_No_Of_Stages
        tmp_str = Stg_Info(m)
                
        'Str_to_BCD "0" + Mid$(tmp_str, 1, 3), filt_str
        Str_to_BCD Format(CStr(Crnt_Start_Stage), "0000"), filt_str
        Crnt_Start_Stage = Crnt_Start_Stage + 1
        
        stg_rec_to_store.Stg_no = Chr$((filt_str And &HFF00) \ 256) + Chr$(filt_str And &HFF)
        stg_rec_to_store.Stg_Cod = Mid$(tmp_str, 5, 3) 'code
        stg_rec_to_store.Stg_Name = Mid$(tmp_str, 9, 11) 'name
        Str_to_BCD Mid$(tmp_str, 21, 4), filt_str
        stg_rec_to_store.Stg_dist = Chr$((filt_str And &HFF00) \ 256) + Chr$(filt_str And &HFF)
        stg_rec_to_store.Stg_mName = Stg_Info_mName(m)
        
        Str_to_BCD ("00" + Mid$(Stg_Info_Id(m), 1, 2)), filt_str
        first = CByte(filt_str And &HFF)
        Str_to_BCD Mid$(Stg_Info_Id(m), 3, 4), filt_str
        stg_rec_to_store.Stg_Id = Chr$(first) + Chr$((filt_str And &HFF00) \ 256) + Chr$(filt_str And &HFF)
        Put #file_no, , stg_rec_to_store
         
   Next m
    
   
   Y = (Crnt_No_Of_Stages * (Crnt_No_Of_Stages - 1)) / 2  'no of entries of fares
   For m = 1 To Y
        tmp_str = Fare_Info(m)
        Str_to_BCD Mid$(tmp_str, 1, 4), filt_str  'Rs.
        Put #file_no, , Chr$((filt_str And &HFF00) \ 256) + Chr$(filt_str And &HFF)
        Str_to_BCD "00" + Mid$(tmp_str, 6, 2), filt_str 'paise
        Put #file_no, , Chr$(filt_str And &HFF)
   Next m
   
   
   
   
   Off_in_rut_tbl_file = Off_in_rut_tbl_file + (Crnt_No_Of_Stages * Size_Of_Stg_Rec) + (Y * 3)
   
End Sub
Private Sub process_stage_line_straight(tmp_str As String, file_no As Integer)
Stg_Info(line_in_rut) = Mid$(tmp_str, 1, 24)
Fare_Info(line_in_rut) = Mid$(tmp_str, 26, 7)
Stg_Info_mName(line_in_rut) = Mid$(tmp_str, 26 + 8, 16)
Stg_Info_Id(line_in_rut) = Mid$(tmp_str, 26 + 8 + 17, 6)
End Sub
Private Sub process_stage_line_triangular(tmp_str As String, file_no As Integer)
Dim m, n As Integer
'stage line is to be process using line_in_rut
'24 + (line_in_rut*8)
Stg_Info(line_in_rut) = Mid$(tmp_str, 1, 24)

    
adr = 1 'adr in the array

    For n = 1 To line_in_rut - 1
    
    tmp_str1 = Mid$(tmp_str, 26 + ((n - 1) * 8), 7)
     adr = line_in_rut - 1
            For m = 2 To n
              adr = adr + Crnt_No_Of_Stages - m
            Next m
      Fare_Info(adr) = tmp_str1
    
    Next n
Stg_Info_mName(line_in_rut) = Mid$(tmp_str, 26 + 8 + ((line_in_rut - 1) * 8), 16)

Stg_Info_Id(line_in_rut) = Mid$(tmp_str, 26 + 8 + 17 + ((line_in_rut - 1) * 8), 6)
End Sub
Private Sub process_first_rut_line(tmp_str As String, file_no As Integer)
Dim filt_str As Long
Dim m, n As Long

'stores this in the Rout_summary file at current pointer
Rout_Summ_rec.Rout_Prgmd = "YY"
 Str_to_BCD "0" + Crnt_Rut_Str, filt_str
 
Rout_Summ_rec.Rout_No = Chr$(CByte((filt_str And &HFF00) \ 256)) + Chr$(CByte(filt_str And &HFF))
 Str_to_BCD "00" + Mid$(tmp_str, 1, 2), filt_str
Rout_Summ_rec.Serv_Cod = Chr$(0) + Chr$(filt_str And &HFF)
Rout_Summ_rec.Serv_typ_str = Mid$(tmp_str, 4, 12)
Rout_Summ_rec.Src_stn_cod = Mid$(tmp_str, 17, 3)
Rout_Summ_rec.Src_stn_name = Mid$(tmp_str, 21, 11)
Rout_Summ_rec.Dst_stn_cod = Mid$(tmp_str, 33, 3)
Rout_Summ_rec.Dst_stn_name = Mid$(tmp_str, 37, 11)
 Str_to_BCD "0" + Mid$(tmp_str, 49, 3), filt_str
Rout_Summ_rec.No_of_stgs = Chr$(CByte((filt_str And &HFF00) \ 256)) + Chr$(CByte(filt_str And &HFF))
 Crnt_No_Of_Stages = Val(Mid$(tmp_str, 49, 3))
 
 Str_to_BCD Mid$(tmp_str, 53, 4), filt_str
Rout_Summ_rec.Dist = Chr$(CByte((filt_str And &HFF00) \ 256)) + Chr$(CByte(filt_str And &HFF))
 'for gettting the adr of rout tbl
 filt_str = Adr_strt_Rout_Tbl + Off_in_rut_tbl_file
 n = filt_str \ 65536
 m = filt_str - (65536 * n)
Rout_Summ_rec.Tbl_Adr = Chr$(CByte(filt_str \ 65536)) + _
                        Chr$(CByte((m And &HFF00) \ 256)) + _
                        Chr$(CByte(filt_str And &HFF))
''now save in summary code file
Rout_Summ_rec.Tbl_typ = Mid$(tmp_str, 58, 1) + Mid$(tmp_str, 58, 1)
'Rout_Summ_rec.Tbl_typ = "TT" 'fixed At present
Crnt_Start_Stage = 1
If (Len(tmp_str) = 62) Then
    Crnt_Start_Stage = Val(Mid$(tmp_str, 60, 3))
    Str_to_BCD "0" + Mid$(tmp_str, 60, 3), filt_str
    If (filt_str) = 0 Then filt_str = 1
    Rout_Summ_rec.StartStg = Chr$(CByte(CByte(filt_str \ 256))) + Chr$(CByte(filt_str And &HFF))
End If

Put #file_no, , Rout_Summ_rec
n = Len(Rout_Summ_rec)

End Sub
Public Sub write_out_file(tmp_str As String)
''check if file is already open with number ??
    Open Apppath + File_Rcvd For Output As #20  'open file for repsonse
    Print #20, tmp_str
    Close #20
End Sub
Public Function check_if_waybil_present()

check_if_waybil_present = False
Handheld.get_data_from_long_eeprom Adr_WayBil, 2 'check if waybil present
    If Handheld.Error_Comm = True Then
        write_Err_In_file Handheld.Error_Code, ""
        check_if_waybil_present = False
        Exit Function
    End If
    
    If Mid$(Handheld.readstr_bin, 1, 2) = "YY" Then
        write_Err_In_file Handheld.Error_Code, "$Error- WayBill is Present"
        check_if_waybil_present = True
    Else
        check_if_waybil_present = False
    End If
    
End Function

Public Function Check_if_mc_data_is_clear()
Dim n As Integer

Handheld.get_data_from_long_eeprom Adr_No_Of_Tckts, 2
    
    If Handheld.Error_Comm = True Then
        write_Err_In_file Handheld.Error_Code, ""
        Check_if_mc_data_is_clear = False
        Exit Function
    End If
'there is response so process
n = Val("&h" + Mid$(Handheld.readstr_asc, 1, 4))

If n = 0 Then
    Check_if_mc_data_is_clear = True
 Else
    write_Err_In_file Handheld.Error_Code, "$Error-Ticket Data Is Present"
    Check_if_mc_data_is_clear = False
End If
End Function
