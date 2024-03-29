﻿using SQLite;
using StudentsHelper.Model;
using StudentsHelper.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace StudentsHelper.DataBase
{
    public class ObjectsDataGetter : DataBaseHelper
    {     
        public static Student GetStudentData()
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new(DataBasePath))
                {
                    Student Student = SQLiteConnection.Table<Student>().FirstOrDefault(s => s.Id == StudentId);
                    if (Student != null)
                    {
                        return Student;
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nNie udało się pobrać danych", "Zaloguj się ponownie");
                return null;
            }
        }

        public static DegreeCourse GetDegreeCourseData()
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new(DataBasePath))
                {
                    DegreeCourse DegreeCourse = SQLiteConnection.Table<DegreeCourse>().FirstOrDefault(s => s.StudentId == StudentId);
                    if (DegreeCourse != null)
                    {
                        return DegreeCourse;
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nNie udało się pobrać danych", "Zaloguj się ponownie");
                return null;
            }
        }

        public static ObservableCollection<Exam> GetExamsData()
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new(DataBasePath))
                {
                    List<Exam> ExamsList = SQLiteConnection.Table<Exam>().Where(e => e.StudentId == StudentId).ToList();
                    ObservableCollection<Exam> Exams = new(ExamsList);
                    if (Exams != null)
                    {
                        return Exams;
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nNie udało się pobrać danych", "Zaloguj się ponownie");
                return null;
            }
        }

        public static ObservableCollection<Test> GetTestsData()
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new(DataBasePath))
                {
                    List<Test> TestsList = SQLiteConnection.Table<Test>().Where(e => e.StudentId == StudentId).ToList();
                    ObservableCollection<Test> Tests = new(TestsList);
                    if (Tests != null)
                    {
                        return Tests;
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nNie udało się pobrać danych", "Zaloguj się ponownie");
                return null;
            }
        }

        public static ObservableCollection<Homework> GetHomeworkData()
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new(DataBasePath))
                {
                    List<Homework> HomeworkList = SQLiteConnection.Table<Homework>().Where(e => e.StudentId == StudentId).ToList();
                    ObservableCollection<Homework> Homework = new(HomeworkList);
                    if (Homework != null)
                    {
                        return Homework;
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nNie udało się pobrać danych", "Zaloguj się ponownie");
                return null;
            }
        }

        public static ObservableCollection<Teacher> GetTeachersData()
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new(DataBasePath))
                {
                    List<Teacher> TeachersList = SQLiteConnection.Table<Teacher>().Where(e => e.StudentId == StudentId).ToList();
                    ObservableCollection<Teacher> Teachers = new(TeachersList);
                    if (Teachers != null)
                    {
                        return Teachers;
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nNie udało się pobrać danych", "Zaloguj się ponownie");
                return null;
            }
        }

        public static ObservableCollection<Note> GetNotesData()
        {
            try
            {
                using (SQLiteConnection SQLiteConnection = new(DataBasePath))
                {
                    List<Note> NotesList = SQLiteConnection.Table<Note>().Where(e => e.StudentId == StudentId).ToList();
                    ObservableCollection<Note> Notes = new(NotesList);
                    if (Notes != null)
                    {
                        return Notes;
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}\nNie udało się pobrać danych", "Zaloguj się ponownie");
                return null;
            }
        }
    }
}