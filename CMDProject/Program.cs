using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Reflection.Emit;
using System.IO.Compression;
using System.Net.Http;

namespace CMDProject
{
    
    internal class Program
    {
        public static string filebytes(string cmd)
        {
            string[] filestrings = Directory.GetFiles(cmd);
            int filecount=filestrings.Length;
            int sum=0;

            foreach(var item in filestrings)
            {
                sum += File.ReadAllBytes(item).Length;
            }
            return filecount+"  File(s)        " + sum + "   byte(s)";
        }
        
        public static string[] dirli(string cmd)
        {
          
           int i = 0;
              
                string[] DiLidt = Directory.GetDirectories(cmd);
            string[] path = new string[DiLidt.Length];
           
            foreach (var d in DiLidt)
                {
               
                path[i]= d;
                i++;
            }
           
            return path;
        }
       
        static void Main()
        {

            Console.Title = "Command Prompt";
  
            DateTime dt = DateTime.Now;
            string result = "";
            string timestamp = "";
            string output = @"c:\Output";
            string text = @"c:\Output\Output(" +dt.Hour+ "-"+dt.Minute+").zip";
            string extractPath = @".\extract";
            if (Directory.Exists(@"c:\Output") == false)
            {
                Directory.CreateDirectory(@"c:\Output");
            }
          
            bool indir = false;
            string cmd = @"C:\";
           
           
            List<string> indirlist= new List<string>();

           
            List<string> list = new List<string>();
            DriveInfo[] Dlist = DriveInfo.GetDrives();
            foreach (DriveInfo d in Dlist)
            {
                list.Add(d.Name);
            }
            
            
            for (; ; )
            {
                void a()
                {

                    Console.Write(cmd);
                    string writec = Console.ReadLine();
                    if (writec.Contains(":"))
                    {
                        if (list.Contains(writec + @"\"))
                        {
                            cmd = writec + @"\";
                        }
                        else
                        {
                            Console.WriteLine("Drive Not Exist");
                           
                            a();
                        }
                    }
                    if (writec.Contains("cd ") && indir == true)
                    {
                        var item = from folder in dirli(cmd)
                                   where folder == cmd + writec.Substring(3)
                                   select folder;
                       
                        if (dirli(cmd).Contains(cmd + writec.Substring(3)))
                        {
                           
                            indirlist.Add(writec.Substring(3));
                            cmd += writec.Substring(3) + @"\";

                           

                        }
                        else
                            Console.WriteLine("Directory Does Not Exist");

                    }


                    if (writec == "cd.." && indir == true)
                    {
                       

                        try
                        {
                            cmd = cmd.Substring(0, cmd.Length - (indirlist.Last().Length) - 1);
                          
                        }
                        catch(Exception x)
                        {
                            Console.WriteLine(x);
                            a();
                        }
                       
                            indirlist.Remove(indirlist.Last());
                           
                       
                       

                    }

                    int cmdlen = writec.Length;


                    List<string> command = new List<string>() { writec };
                   
                   
                    
                        if (writec == "dir")
                        {
                        try
                        {
                           
                            //int maxle=dirli(cmd).Max(c=>c.Length);
                            ////Console.WriteLine(maxle);
                            foreach (var d in dirli(cmd))
                            {
                                //    string rpl;
                                //    rpl = d;
                                //    for(int i = rpl.Length; i < maxle; i++)
                                //    {
                                //        if(rpl.Length<maxle)
                                //        {
                                //            rpl += " "; 
                                //        }
                                //    }


                                Console.WriteLine(Directory.GetCreationTime(d).ToString("yyyy/MM/dd hh:mm tt") + "\t\t\t"+ Path.GetFileNameWithoutExtension(d));
                                
                            }
                            //Console.WriteLine(filebytes(cmd));
                           
                            indir = true;
                            
                        }
                        catch(Exception x)
                        {
                            Console.WriteLine(x);
                           
                        }
                        a();
                    }
                    
                  
                    var drv = command.Where(c => c.Contains(":")).ToList();
                  

                    if (writec.Length == 0)
                    {
                        
                        a();
                    }
                   
                    else if(! writec.Contains("cd ") && !writec.Contains("dir") && writec!="cd.." &&! writec.Contains(":"))
                    {
                        Console.WriteLine("Invalid Input");
                        a();
                    }
                   

                }
                //Console.Write("\nPress 'E' to exit the process...");

                //// here it asks to press "E" to exit
                //// and the key "E" is not shown in
                //// the console output window
                //while (Console.ReadKey(true).Key != ConsoleKey.E)
                //{
                //}
                a();
               
                //using (FileStream fs = File.Create(@"c:\Output\Output(" + dt.Hour + "-" + dt.Minute + ").txt"))
                //{
                //    timestamp +=result ;
                //    byte[] info = new UTF8Encoding(true).GetBytes(result + Environment.NewLine);
                //    fs.Write(info, 0, info.Length);
                //}
                //try
                //{

                //    ZipFile.CreateFromDirectory(output, text);

                //    ZipFile.ExtractToDirectory(text, extractPath);
                  
                //}
                //catch (Exception) { }

            }

        }
           
    }
}
