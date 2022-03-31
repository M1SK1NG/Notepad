using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows;
using Linux;




namespace Linux
{
    class Class1
    {
        string path;
        string nameFile;
        RichTextBox fieldEdit;
        bool result2;
        public bool Modified { get; set; }
        public string NameFile
        {
            get { return nameFile; }
        }
        public Class1(RichTextBox fieldEdit)
        {
            nameFile = "";



            this.fieldEdit = fieldEdit;
            Modified = false;
        }
        public void NewWindow()
        {

        }
        public bool ASaveBloknot()
        {


            SaveFileDialog sd = new SaveFileDialog();
            sd.DefaultExt = "rtf";
            sd.Filter = "Текстовый файл (*.rtf) |*.rtf|Все файлы(*.*)|*.*";
            if (nameFile == "")
                if (sd.ShowDialog() == true)
                    nameFile = sd.FileName;
                else return false;
            TextRange doc = new TextRange(fieldEdit.Document.ContentStart, fieldEdit.Document.ContentEnd);
            FileStream fs = File.Create(sd.FileName);
            doc.Save(fs, DataFormats.Rtf);
            fs.Close();
            Modified = false;
            return true;
        }
        public void Create()
        {
            if (Modified == true)
            {
                MessageBoxResult result;
                //Спросить о сохранении файла ДА/НЕТ/ОТМЕНА
                result = MessageBox.Show("Вы хотите сохранить изменения в файле", "Сохранение", MessageBoxButton.YesNoCancel,MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)



                    //прерываем событие (отмена текущего действия)
                    if (ASaveBloknot() == false) return;
                
                if (result == MessageBoxResult.Cancel) return;
            }
            //При успешном развитии событий
            fieldEdit.Document.Blocks.Clear();//Ouvuaem 6n0KHOT
            nameFile = "";//Очищаем имя файла
            Modified = false;//Сброс признака редактирования
        }
        public void SaveNoAccess()
        {
            path = Path.GetDirectoryName(NameFile);





            TextRange documentTextRange = new TextRange(fieldEdit.Document.ContentStart, fieldEdit.Document.ContentEnd);

            using (FileStream fs = File.Create(nameFile))
            {
                if (System.IO.Path.GetExtension(nameFile).ToLower() == ".rtf")
                {
                    documentTextRange.Save(fs, DataFormats.Text);

                }
            }


        }
        public void Save()

        {
            if (File.Exists(NameFile))
            {
                path = Path.GetDirectoryName(NameFile);




                {
                    MessageBoxResult result1;


                    result1 = MessageBox.Show("Вы желаете сохранить изминения?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result1 == MessageBoxResult.Yes)
                    {
                        TextRange documentTextRange = new TextRange(fieldEdit.Document.ContentStart, fieldEdit.Document.ContentEnd);

                        using (FileStream fs = File.Create(nameFile))
                        {
                            if (System.IO.Path.GetExtension(nameFile).ToLower() == ".rtf")
                            {
                                documentTextRange.Save(fs, DataFormats.Text);
                                result2 = true;
                            }
                        }

                    }
                    if (result1 == MessageBoxResult.No)
                    {
                        result2 = false;
                    }
                   

                }


            }

            else
            {

                MessageBoxResult result;

                result = MessageBox.Show("Вы желаете сохранить новый файл?", "Сохранение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    ASaveBloknot();

                }
                if (result == MessageBoxResult.No)
                {

                }
            }


        }
        public void FollowingPose()
        {
           
            fieldEdit.CaretPosition = fieldEdit.CaretPosition.GetNextInsertionPosition(LogicalDirection.Forward);
        }

        public void DeleteThisLine()
        {
            
            fieldEdit.CaretPosition = fieldEdit.CaretPosition.GetNextContextPosition(LogicalDirection.Forward);
            fieldEdit.CaretPosition.DeleteTextInRun(-250);
            
        }
        public void OpenFile()
        {
            
            if (Modified == true)
            {
                if (File.Exists(NameFile))
                {
                    MessageBoxResult result;
                    if (result2 == false)
                    {
                        result = MessageBox.Show("Вы хотите сохранить изменения?", "Сохранение", MessageBoxButton.YesNo,MessageBoxImage.Question);

                        if (result == MessageBoxResult.Yes)
                        {
                            SaveNoAccess();
                            OpenFileDialog ofd = new OpenFileDialog();
                            ofd.Filter = "RichText Files (*.rtf)|*.rtf|All files (*.*)|*.*";

                            if (ofd.ShowDialog() == true)
                            {
                                nameFile = ofd.FileName;
                                TextRange doc = new TextRange(fieldEdit.Document.ContentStart, fieldEdit.Document.ContentEnd);
                                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                                {
                                    if (Path.GetExtension(ofd.FileName).ToLower() == ".rtf")
                                        doc.Load(fs, DataFormats.Rtf);
                                    else if (Path.GetExtension(ofd.FileName).ToLower() == ".txt")
                                        doc.Load(fs, DataFormats.Text);
                                    else
                                        doc.Load(fs, DataFormats.Xaml);
                                }
                            }
                        }
                        if (result == MessageBoxResult.No)
                        {
                            OpenFileDialog ofd = new OpenFileDialog();
                            ofd.Filter = "RichText Files (*.rtf)|*.rtf|All files (*.*)|*.*";

                            if (ofd.ShowDialog() == true)
                            {
                                nameFile = ofd.FileName;
                                TextRange doc = new TextRange(fieldEdit.Document.ContentStart, fieldEdit.Document.ContentEnd);
                                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                                {
                                    if (Path.GetExtension(ofd.FileName).ToLower() == ".rtf")
                                        doc.Load(fs, DataFormats.Rtf);
                                    else if (Path.GetExtension(ofd.FileName).ToLower() == ".txt")
                                        doc.Load(fs, DataFormats.Text);
                                    else
                                        doc.Load(fs, DataFormats.Xaml);
                                }
                            }
                        }
                    }
                    if (result2 == true)
                    {
                        SaveNoAccess();
                    }           
                }
                    if (!File.Exists(NameFile))
                    {
                        MessageBoxResult result3;
                        result3 = MessageBox.Show("Вы хотите сохранить новый документ?", "Сохранить как", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                        if (result3 == MessageBoxResult.Yes)
                        {
                            ASaveBloknot();
                        OpenFileDialog ofd = new OpenFileDialog();
                        ofd.Filter = "RichText Files (*.rtf)|*.rtf|All files (*.*)|*.*";

                        if (ofd.ShowDialog() == true)
                        {
                            nameFile = ofd.FileName;
                            TextRange doc = new TextRange(fieldEdit.Document.ContentStart, fieldEdit.Document.ContentEnd);
                            using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                            {
                                if (Path.GetExtension(ofd.FileName).ToLower() == ".rtf")
                                    doc.Load(fs, DataFormats.Rtf);
                                else if (Path.GetExtension(ofd.FileName).ToLower() == ".txt")
                                    doc.Load(fs, DataFormats.Text);
                                else
                                    doc.Load(fs, DataFormats.Xaml);
                            }
                        }
                    }
                        if (result3 == MessageBoxResult.No)
                        {
                        OpenFileDialog ofd = new OpenFileDialog();
                        ofd.Filter = "RichText Files (*.rtf)|*.rtf|All files (*.*)|*.*";

                        if (ofd.ShowDialog() == true)
                        {
                            nameFile = ofd.FileName;
                            TextRange doc = new TextRange(fieldEdit.Document.ContentStart, fieldEdit.Document.ContentEnd);
                            using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                            {
                                if (Path.GetExtension(ofd.FileName).ToLower() == ".rtf")
                                    doc.Load(fs, DataFormats.Rtf);
                                else if (Path.GetExtension(ofd.FileName).ToLower() == ".txt")
                                    doc.Load(fs, DataFormats.Text);
                                else
                                    doc.Load(fs, DataFormats.Xaml);
                            }
                        }
                    }
                        if (result3 == MessageBoxResult.Cancel)
                        {
                            
                        }
                }
                
            }
            
        }
    }
}     
            
                    
                

            
         
            
           
        
    

