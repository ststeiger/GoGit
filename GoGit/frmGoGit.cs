
using System.Windows.Forms;


namespace GoGit
{


    public partial class frmGoGit : Form
    {

        private System.IO.StreamWriter m_stdin;


        public frmGoGit()
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            
            InitializeComponent();
        } // End Constructor 


        private void btnCommitAndPush_Click(object sender, System.EventArgs e)
        {
            CommitAndPushWithGit();
        }


        private void CommitAndPushWithGit()
        {
            int iTimeout = 0;
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("cmd.exe");
            psi.CreateNoWindow = false;
            psi.UseShellExecute = false;
            psi.WorkingDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            psi.RedirectStandardInput = true;

            string envPath = psi.EnvironmentVariables["Path"];
            envPath += @";D:\Programme\Git\bin";
            psi.EnvironmentVariables["Path"] = envPath;
            // psi.EnvironmentVariables = dictionary;   
            // psi.EnvironmentVariables["PATH"] = dictionary.Replace(@"\\", @"\");


            psi.Arguments = "/k \"net use\"";

            using (System.Diagnostics.Process p = new System.Diagnostics.Process())
            {
                p.StartInfo = psi;
                /*
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;

                // hookup the eventhandlers to capture the data that is received
                p.OutputDataReceived += delegate(object sender, System.Diagnostics.DataReceivedEventArgs e)
                {
                    string stringResults = e.Data;
                    // do some work on stringResults...
                    // results = stringResults;
                    // System.Windows.Forms.MessageBox.Show(stringResults);
                    System.Console.WriteLine(stringResults);
                };

                p.ErrorDataReceived += delegate(object sender, System.Diagnostics.DataReceivedEventArgs args)
                {
                    string stringResults = args.Data;
                    // sb.AppendLine(args.Data)
                    System.Console.WriteLine(stringResults);
                };
                */

                p.Start();
                //using (System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi))
                //{
                // p.BeginOutputReadLine();
                // p.BeginErrorReadLine();


                // using (System.IO.StreamWriter sw = p.StandardInput)
                m_stdin = p.StandardInput;
                {
                    if (m_stdin.BaseStream.CanWrite)
                    {
                        // https://stackoverflow.com/questions/17743549/git-recursively-add-the-entire-folder


                        if(!System.IO.Directory.Exists(System.IO.Path.Combine(psi.WorkingDirectory,".git")))
                        {
                            string fn = System.IO.Path.Combine(psi.WorkingDirectory, ".gitignore");

                            if(!System.IO.File.Exists(fn))
                                System.IO.File.WriteAllText(fn, Helpers.GetGitignoreFile(), System.Text.Encoding.UTF8);


                            m_stdin.WriteLine("git init");
                            // git add README.md

                            if(string.IsNullOrEmpty(this.txtRepo.Text) || this.txtRepo.Text.Trim() == string.Empty)
                                m_stdin.WriteLine("git remote add origin https://github.com/ststeiger/GolangTestRepo.git");
                            else
                                m_stdin.WriteLine("git remote add origin " + this.txtRepo.Text);
                        } // End if(!System.IO.Directory.Exists(System.IO.Path.Combine(psi.WorkingDirectory,".git"))) 


                        // https://stackoverflow.com/questions/17743549/git-recursively-add-the-entire-folder
                        m_stdin.WriteLine("git add --all");
                        m_stdin.WriteLine("git commit -am \"" + @"Automatically commited on " + Helpers.GetLocalTime() + "\"");
                        // m_stdin.WriteLine("git push");
                        m_stdin.WriteLine("git push -u origin master");
                    } // End if (m_stdin.BaseStream.CanWrite) 

                } // "End Using" m_stdin 
                
                p.WaitForExit(iTimeout);
            } // End Using p

        } // End Sub StartProcess 


    } // End Class frmGoGit : Form


} // End Namespace GoGit
