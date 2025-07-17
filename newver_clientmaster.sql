-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Apr 10, 2023 at 11:03 AM
-- Server version: 5.7.23
-- PHP Version: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `automate_automateds`
--

-- --------------------------------------------------------

--
-- Table structure for table `newver_clientmaster`
--

DROP TABLE IF EXISTS `newver_clientmaster`;
CREATE TABLE IF NOT EXISTS `newver_clientmaster` (
  `ID` int(100) NOT NULL AUTO_INCREMENT,
  `ClientID` varchar(25) DEFAULT NULL,
  `IsActive` bit(1) DEFAULT NULL,
  `Description` varchar(250) DEFAULT NULL,
  `GroupID` varchar(100) NOT NULL,
  `ClientRole` int(10) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ID`),
  KEY `Grp` (`GroupID`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `newver_clientmaster`
--

INSERT INTO `newver_clientmaster` (`ID`, `ClientID`, `IsActive`, `Description`, `GroupID`, `ClientRole`) VALUES
(1, 'AUTOMATE', b'1', 'AUTOMATE', 'AUTOMATE', 1),
(2, 'HTCGAJ01', b'0', 'HTCGAJ01', 'HANUMAN1', 1),
(3, 'AEYGEE01', b'1', 'Mr Sahadevan', 'AEYGEE01', 0),
(4, 'CHARTER1', b'0', 'INDORE E-BUS', 'INDORE01', 1),
(5, 'CCTHOFF1', b'1', 'Udupi Head Office1  Trial Dec19', 'CCTUDUPI', 1),
(6, 'DURGAMBA', b'1', 'DURGAMBA MOTORS', 'CCTUDUPI', 0),
(7, 'APMHEBRI', b'1', 'A P M HEBRI', 'CCTUDUPI', 0),
(8, 'SRIDURGA', b'1', 'SRI DURGAMBA TRAVELS', 'CCTUDUPI', 0),
(9, 'VISHALMT', b'1', 'VISHAL MOTORS', 'CCTUDUPI', 0),
(10, 'SRIMKBKA', b'1', 'SRI MUKAMBIKA', 'CCTUDUPI', 0),
(11, 'SRIGANES', b'1', 'SRI GANESH MOTORS', 'CCTUDUPI', 0),
(12, 'SAMATHA1', b'1', 'SAMATHA MOTORS', 'CCTUDUPI', 0),
(14, 'JYBALLAL', b'1', 'JAYRAJ BALLAL', 'CCTUDUPI', 0),
(15, 'SRIRAVAL', b'1', 'SRI RAVALNATH MOTORS', 'CCTUDUPI', 0),
(16, 'DAYAJEET', b'0', 'Indore Prasanna', 'INDORE02', 1),
(17, 'VISHLTRV', b'1', 'VISHAL TRAVELS CCT', 'CCTUDUPI', 0),
(18, 'SNDPTRVL', b'1', 'S.N.D.P. CCT', 'CCTUDUPI', 0),
(19, 'RJKRTRVL', b'1', 'RAJKUMAR TRAVELS CCT', 'CCTUDUPI', 0),
(20, 'UJWLMTRS', b'0', 'Ujwal Motors CCT (Xfer to SRIRAVAL 25.02.21)', 'CCTUDUPI', 0),
(21, 'HMTRVLS1', b'1', 'HMT CCT', 'CCTUDUPI', 0),
(22, 'BHRTKVRI', b'0', 'BHARATH KAVERI CCT', 'CCTUDUPI', 0),
(23, 'SRICHKRA', b'1', 'SHREE CHAKRA CCT', 'CCTUDUPI', 0),
(24, 'SLAXGANM', b'1', 'Sri Laxmi Ganesh Mangalore', 'CCTUDUPI', 0),
(25, 'SRISRVNA', b'1', 'Sri Sarvana,(TRICHY Shakthi)', 'CCTUDUPI', 0),
(26, 'MRLITRVL', b'1', 'Maroli Travels(CCT)', 'CCTUDUPI', 0),
(27, 'SRDURGAA', b'1', 'CCT', 'CCTUDUPI', 0),
(28, 'SRVJYLXM', b'1', 'CCT SRI VIJAYA LAXMI', 'CCTUDUPI', 0),
(29, 'CNRTRVLS', b'1', 'CCT- CANARA TRAVELS', 'CCTUDUPI', 0),
(30, 'RSHMMTRS', b'1', 'CCT-RESHMA MOTORS', 'CCTUDUPI', 0),
(31, 'SRLGNKKL', b'1', 'CCT-SRI LAXMI GANESH KARKALA', 'CCTUDUPI', 0),
(32, 'SNVDPRSD', b'1', 'CCT- SRI NAV DURGA PRASAD ', 'CCTUDUPI', 0),
(33, 'SLXMBRHM', b'1', 'CCT- SRI LAXMI BRAMHAVARA ', 'CCTUDUPI', 0),
(34, 'SRGNJRKL', b'1', 'Shri Ganesh Jarkala', 'SRGNJRKL', 1),
(35, 'CHKRNMBR', b'1', 'Christa Kiran MoodBidri', 'CHKRNMBR', 0),
(36, 'GAJINCCT', b'1', 'Gajanana Motors,Sagara, under CCT', 'CCTUDUPI', 0),
(38, 'SRDEVMLP', b'1', 'SRI DEVIPRASAD,MALPE Uder CCT', 'CCTUDUPI', 0),
(39, 'SRAJMANG', b'1', 'SHRIRAJ TRAVELS NAMGALORE,KARKALA CCT\r\n', 'SRAJMANG', 1);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
