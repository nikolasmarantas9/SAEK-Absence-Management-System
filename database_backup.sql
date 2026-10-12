-- phpMyAdmin SQL Dump
-- Database: `students_db`

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

CREATE DATABASE IF NOT EXISTS `students_db` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `students_db`;

-- --------------------------------------------------------

--
-- Table structure for table `absences`
--

CREATE TABLE `absences` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `hours` int(11) NOT NULL,
  `course_name` varchar(255) NOT NULL,
  `absence_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `absences`
--

INSERT INTO `absences` (`id`, `name`, `hours`, `course_name`, `absence_date`) VALUES
(1, 'Γιώργος Παπαδόπουλος', 4, 'Προγραμματισμός', '2024-05-15'),
(2, 'Μαρία Νικολάου', 2, 'Μαθηματικά', '2024-05-16');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `absences`
--
ALTER TABLE `absences`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `absences`
--
ALTER TABLE `absences`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;
