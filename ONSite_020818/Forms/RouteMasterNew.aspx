<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RouteMasterNew.aspx.cs" Inherits="AutomateTRYOUT.Forms.RouteMasterNew" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>


    <%--    <asp:UpdatePanel ID="upnlAdd" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>--%>
    <asp:Button ID="btnAddNew" runat="server" Text="Add New Route" OnClick="btnAddNew_Click" Font-Bold="true" Font-Size="Medium" Visible="False" />
    <asp:Panel ScrollBars="Horizontal" ID="pnlAdd" runat="server" Visible="false" BorderWidth="1px">

        <table align="center">
            <tr>
                <td>
                    <asp:Label Font-Size="Medium" ID="lblrouteno" runat="server" Text="Route No." CssClass="rightAlign"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtrouteno" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVrouteno" runat="server" ForeColor="Red" ErrorMessage="Required Field route no" ControlToValidate="txtrouteno" ValidationGroup="Save"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtrouteno"
                        ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="Save">        </asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:Label Font-Size="Medium" ID="lblfarechanged" runat="server" Text="Fare Changed" CssClass="rightAlign"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtfarechanged" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="rfvfarechanged" runat="server" ControlToValidate="txtfarechanged"
                        ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="Save">        </asp:RegularExpressionValidator>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblroutetype" Font-Size="Medium" runat="server" Text="Route Type" CssClass="rightAlign"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtroutetype" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvroutetype" runat="server" ForeColor="Red" ErrorMessage="Required Field route type" ControlToValidate="txtroutetype" ValidationGroup="Save"></asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="rdvtxtroutetype" runat="server" ControlToValidate="txtroutetype"
                        ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="Save">        </asp:RegularExpressionValidator>
                </td>

                <td>
                    <asp:Label ID="lblbustype" Font-Size="Medium" runat="server" Text="Bus Type" CssClass="rightAlign"></asp:Label>
                </td>
                <td>

                    <asp:TextBox ID="txtbustype" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtbustype" runat="server" ForeColor="Red" ErrorMessage="Required Field bus type" ControlToValidate="txtbustype" ValidationGroup="Save"></asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="revbustype" runat="server" ControlToValidate="txtbustype"
                        ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="Save">        </asp:RegularExpressionValidator>

                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="lbltriangleno" Font-Size="Medium" runat="server" Text="Triangle no" CssClass="rightAlign"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txttriangleno" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfviangleno" runat="server" ForeColor="Red" ErrorMessage="Required Field triangle no" ControlToValidate="txttriangleno" ValidationGroup="Save"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revtriangleno" runat="server" ControlToValidate="txttriangleno"
                        ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="Save">        </asp:RegularExpressionValidator>
                </td>

                <td>
                    <asp:Label ID="lblstartstg" Font-Size="Medium" runat="server" Text="Stage Start" CssClass="rightAlign"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtstartstg" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtstartstg" runat="server" ForeColor="Red" ErrorMessage="Required Field Start Stage  " ControlToValidate="txtstartstg" ValidationGroup="Save"></asp:RequiredFieldValidator>

                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblendstg" Font-Size="Medium" runat="server" Text="Stage End " CssClass="rightAlign"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtendstg" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtendstg" runat="server" ForeColor="Red" ErrorMessage="Required Field End Stage   " ControlToValidate="txtendstg" ValidationGroup="Save"></asp:RequiredFieldValidator>

                </td>


                <td>
                    <asp:Label ID="lblstgmarathiname" Font-Size="Medium" runat="server" Text="Stage Marathi Name" CssClass="rightAlign"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtstgmarathiname" runat="server"></asp:TextBox>


                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblnoofstops" Font-Size="Medium" runat="server" Text="No of Stops" CssClass="rightAlign"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtnoofstops" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtnoofstops" runat="server" ForeColor="Red" ErrorMessage="Required Field No of Stops " ControlToValidate="txtnoofstops" ValidationGroup="Save"></asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="rfvnoofstops" runat="server" ControlToValidate="txtnoofstops"
                        ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="Save">        </asp:RegularExpressionValidator>

                </td>


            </tr>


            <tr>

                <td></td>
                <td></td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="60px" ValidationGroup="Save" OnClick="btnSave_Click" />

                    <asp:Button ID="btnReset" runat="server" Text="Cancel" Width="60px" OnClick="btnReset_Click" />

                </td>

            </tr>


        </table>
    </asp:Panel>




    <asp:Panel ScrollBars="Horizontal" ID="pnlgvRouteMaster" runat="server">
        <h1>Route Master</h1>
        <asp:GridView ID="gvRouteMasterr" runat="server" CssClass="pagination-ys" AutoGenerateColumns="False"
             AllowPaging="True" 
             CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%"
             OnRowEditing="gvRouteMasterr_RowEditing"
             OnRowUpdating="gvRouteMasterr_RowUpdating" OnRowCancelingEdit="gvRouteMasterr_RowCancelingEdit" OnPageIndexChanged="gvRouteMasterr_PageIndexChanged"
             OnPageIndexChanging="gvRouteMasterr_PageIndexChanging" PageSize="15">
            <AlternatingRowStyle BackColor="White" />
            <PagerStyle CssClass="pagination-ys" />
            <Columns>

                <asp:TemplateField HeaderText="Edit" Visible="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="Edit"></asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Update"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                </asp:TemplateField>



                <asp:TemplateField HeaderText="View" Visible="False">
                    <ItemTemplate>
                        <%--  <asp:LinkButton ID="lnkView" runat="server" CausesValidation="False" CommandName="view"   Text="view"></asp:LinkButton>--%>
                        <asp:Button ID="btnview" runat="server" Text="View" OnClick="btnview_Click" />
                    </ItemTemplate>

                </asp:TemplateField>

                <asp:TemplateField HeaderText="ID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblid" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Route Number">
                    <ItemTemplate>
                        <asp:Label ID="lblrp_routeno" runat="server" Text='<%#Eval("rp_routeno") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Route Type" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblFirstLineGrid" runat="server" Text='<%#Eval("rp_routetype") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Bus Type" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblrp_bustype" runat="server" Text='<%#Eval("rp_bustype") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Triangle Number">
                    <ItemTemplate>
                        <asp:Label ID="lblrp_triangleno" runat="server" Text='<%#Eval("rp_triangleno") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>

                        <asp:TextBox ID="txtrp_triangleno" runat="server" Text='<%#Eval("rp_triangleno") %>'></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revgvtxtrp_triangleno" runat="server" ControlToValidate="txtrp_triangleno"
                            ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$">        </asp:RegularExpressionValidator>


                    </EditItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Start Stage">
                    <ItemTemplate>
                        <asp:Label ID="lblrp_startstg" runat="server" Text='<%#Eval("rp_startstg") %>'></asp:Label>
                    </ItemTemplate>

                    <EditItemTemplate>

                        <asp:TextBox ID="txtrp_startstg" runat="server" Text='<%#Eval("rp_startstg") %>'></asp:TextBox>



                    </EditItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="End Stage">
                    <ItemTemplate>
                        <asp:Label ID="lblrp_endstg" runat="server" Text='<%#Eval("rp_endstg") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>

                        <asp:TextBox ID="txtrpendstg" runat="server" Text='<%#Eval("rp_endstg") %>'></asp:TextBox>



                    </EditItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Number Of Stops">
                    <ItemTemplate>
                        <asp:Label ID="lblrp_noofstops" runat="server" Text='<%#Eval("rp_noofstops") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>

                        <asp:TextBox ID="txtrpnoofstops" runat="server" Text='<%#Eval("rp_noofstops") %>'></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revgvtxtrpnoofstops" runat="server" ControlToValidate="txtrpnoofstops"
                            ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$">        </asp:RegularExpressionValidator>


                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Local Name">
                    <ItemTemplate>
                        <asp:Label ID="lblrp_stgmarathiname" runat="server" Text='<%#Eval("rp_stgmarathiname") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fare Changed">
                    <ItemTemplate>
                        <asp:Label ID="lblfarechanged" runat="server" Text='<%#Eval("farechanged") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>



            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />

            <PagerSettings Mode="NumericFirstLast" PageButtonCount="3" FirstPageText="First" LastPageText="Last"></PagerSettings>
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <asp:HiddenField ID="HfCurrentLoc" runat="server" />
    </asp:Panel>

    <table>
        <tr>
            <td></td>
        </tr>


    </table>



    <asp:Button ID="btnAddNewSubRoute" runat="server" Text="Add New Sub Route" Visible="false" OnClick="btnAddNewSubRoute_Click" />
    <asp:Panel ScrollBars="Horizontal" ID="PnlSubRoute" runat="server" BorderWidth="1px" Visible="false">

        <table align="center">
            <tr>

                <td>
                    <asp:Label ID="lblsubstgidin" Font-Size="Medium" runat="server" Text="Intrsstg" CssClass="rightAlign"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtsubsubstgidin" runat="server" ></asp:TextBox>
                   <asp:RequiredFieldValidator ID="rfvIntrsstg" runat="server" ForeColor="Red" ErrorMessage="Required Field Intrsstg" ControlToValidate="txtsubsubstgidin" ValidationGroup="BtnSubRouteSave"></asp:RequiredFieldValidator>
                    
                </td>
                <td>
                    <asp:Label ID="lblsubbustype" Font-Size="Medium" runat="server" Text="Bus type" CssClass="rightAlign"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtsubbustype" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="Required Field Bus type" ControlToValidate="txtsubbustype" ValidationGroup="BtnSubRouteSave"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtsubbustype"
                        ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="BtnSubRouteSave">        </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblstgcode" Font-Size="Medium" runat="server" Text="Stage code" CssClass="rightAlign"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtstgcode" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtstgcode" ForeColor="Red" runat="server" ErrorMessage="Required Field stg code" ControlToValidate="txtstgcode" ValidationGroup="BtnSubRouteSave"></asp:RequiredFieldValidator>


                </td>

                <td>
                    <asp:Label ID="lblsubstgnamee" Font-Size="Medium" runat="server" Text="Stage namee" CssClass="rightAlign"></asp:Label>
                </td>
                <td>

                    <asp:TextBox ID="txtsubstgnamee" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ErrorMessage="Required Field Stage namee" ControlToValidate="txtsubstgnamee" ValidationGroup="BtnSubRouteSave"></asp:RequiredFieldValidator>



                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="lblsubTriangleno" Font-Size="Medium" runat="server" Text="Triangle no" CssClass="rightAlign"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtsubTriangleno" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ErrorMessage="Required Field Triangle no" ControlToValidate="txtsubTriangleno" ValidationGroup="BtnSubRouteSave"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtsubTriangleno"
                        ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="BtnSubRouteSave">        </asp:RegularExpressionValidator>
                </td>

                <td>
                    <asp:Label ID="lblsubstgnamem" Font-Size="Medium" runat="server" Text="Stage namem " CssClass="rightAlign"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtsubstgnamem" runat="server"></asp:TextBox>

                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblsubkm" runat="server" Font-Size="Medium" Text="Stage KM" CssClass="rightAlign"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtsubkm" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="Required Field KM" ControlToValidate="txtsubkm" ValidationGroup="BtnSubRouteSave"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtsubkm"
                        ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="Save">        </asp:RegularExpressionValidator>
                </td>

                <td>
                    <asp:Label ID="lblsubstgno" Font-Size="Medium" runat="server" Text="Stg no" CssClass="rightAlign"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtsubstgno" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ErrorMessage="Required Field Stg no" ControlToValidate="txtsubstgno" ValidationGroup="BtnSubRouteSave"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtsubstgno"
                        ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="Save">        </asp:RegularExpressionValidator>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblsubsub" runat="server" Font-Size="Medium" Text="rpsd Sub" CssClass="rightAlign"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtsubsub" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtsubsub"
                        ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="BtnSubRouteSave">        </asp:RegularExpressionValidator>

                </td>

                <td>
                    <asp:Label ID="lblsubintrsstg"  Font-Size="Medium" runat="server" Text="rpsd_stgid" CssClass="rightAlign"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtsubintrsstg" runat="server"></asp:TextBox>
                </td>

            </tr>


            <tr>
                <td>
                    <asp:Label ID="lblsubfarenormal" Font-Size="Medium" runat="server" Text="Fare Normal in" CssClass="rightAlign"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtsubfarenormal" runat="server"></asp:TextBox>

                    <asp:RegularExpressionValidator ID="revsublblsubfarenormal" runat="server" ControlToValidate="txtsubfarenormal"
                        ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="BtnSubRouteSave">        </asp:RegularExpressionValidator>

                </td>



            </tr>

            <tr>

                <td></td>
                <td></td>
                <td>
                    <asp:Button ID="Button1" Font-Size="Medium" runat="server" Text="Save" Width="60px" ValidationGroup="BtnSubRouteSave" OnClick="Button1_Click" />

                    <asp:Button ID="BtnSubRouteCancel" runat="server" Text="Cancel" Width="60px"  Font-Size="Medium" OnClick="BtnSubRouteCancel_Click" />

                </td>

            </tr>


        </table>
    </asp:Panel>

    <asp:Panel ScrollBars="Horizontal" ID="PlnSubRouteMaster" runat="server" Visible="false">
        <h1>Route Details </h1>
        <asp:GridView ID="gvSubRouteMaster" runat="server" CssClass="pagination-ys" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanged="gvSubRouteMaster_PageIndexChanged" OnPageIndexChanging="gvSubRouteMaster_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowDeleting="gvSubRouteMaster_RowDeleting" PageSize="50"
            OnRowEditing="gvSubRouteMaster_RowEditing" OnRowUpdating="gvSubRouteMaster_RowUpdating" OnRowCancelingEdit="gvSubRouteMaster_RowCancelingEdit">
            <AlternatingRowStyle BackColor="White" />
            <Columns>


                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <span onclick="return confirm('Are you sure to Delete the record?')">
                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                Text="Delete">
                            </asp:LinkButton>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="Edit"></asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Update"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="id" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblSubId" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Route No">
                    <ItemTemplate>
                        <asp:Label ID="lblSubrpsd_routeno" runat="server" Text='<%#Eval("rpsd_routeno") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Code">
                    <ItemTemplate>
                        <asp:Label ID="lblrpsd_stgcode" runat="server" Text='<%#Eval("rpsd_stgcode") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>

                        <asp:TextBox ID="txtgvrpsdstgcode" runat="server" Text='<%#Eval("rpsd_stgcode") %>'></asp:TextBox>



                    </EditItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Triangle no">
                    <ItemTemplate>
                        <asp:Label ID="lblsubrpsd_triangleno" runat="server" Text='<%#Eval("rpsd_triangleno") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>

                        <asp:TextBox ID="txtsubrpsdtriangleno" runat="server" Text='<%#Eval("rpsd_triangleno") %>'></asp:TextBox>



                    </EditItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Stage No">
                    <ItemTemplate>
                        <asp:Label ID="lblStageNo" runat="server" Text='<%#Eval("StageNo") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>

                        <asp:TextBox ID="txtgvStageNo" runat="server" Text='<%#Eval("StageNo") %>'></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revgvtxtrp_triangleno" runat="server" ControlToValidate="txtgvStageNo"
                            ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$">        </asp:RegularExpressionValidator>


                    </EditItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Stage Name">
                    <ItemTemplate>
                        <asp:Label ID="lblrpsd_stgnamee" runat="server" Text='<%#Eval("rpsd_stgnamee") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>

                        <asp:TextBox ID="txtgvrpsd_stgnamee" runat="server" Text='<%#Eval("rpsd_stgnamee") %>'></asp:TextBox>



                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Distance">
                    <ItemTemplate>
                        <asp:Label ID="lblrpsd_km" runat="server" Text='<%#Eval("Distance") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>



                <asp:TemplateField HeaderText="Fare" FooterStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblrpsd_stgno" runat="server" Text='<%#Eval("Fare") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>




            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    </asp:Panel>

    <asp:HiddenField ID="hifRouteno" runat="server" />


    <table>

        <tr>
            <td>
                <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="ForestGreen" Visible="false"></asp:Label>
                <asp:Label ID="lblErrMsg" runat="server" ForeColor="Red" Text=""
                    Visible="false"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>

        <tr>
            <td>
                <asp:HiddenField ID="hfEntityCode" runat="server" />
            </td>
            <td>
                <%--<asp:ValidationSummary ID="valAdd" runat="server" ShowMessageBox="false" ShowSummary="true" DisplayMode="BulletList" ValidationGroup="Save" />--%>
            </td>

        </tr>
    </table>

    <%--    </ContentTemplate>
                </asp:UpdatePanel>--%>
</asp:Content>
