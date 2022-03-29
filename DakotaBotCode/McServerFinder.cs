namespace Namespace {
    
    using MinecraftServer = mcstatus.MinecraftServer;
    
    using os;
    
    using math;
    
    using threading;
    
    using time;
    
    using System.Collections.Generic;
    
    using System.Linq;
    
    using System;
    
    public static class Module {
        
        public static object masscan = new List<object>();
        
        static Module() {
            time.sleep(1);
            outfile.close;
            fileHandler.close();
            masscan.append(line.strip().split(" ", 4)[3]);
            time.sleep(2);
        }
        
        public static object inputfile = input("What is the name of the text file with the server ips? (Including the .txt): ");
        
        public static object outputfile = input("What is the name of the text file you want to add the ips to? (Including the .txt): ");
        
        public static object publicserverlist = input("What is the name of the text file with the public server ips? (Including the .txt): ");
        
        public static object searchterm = input("What version are you targeting? (Leave blank for targeting all servers): ");
        
        public static object outfile = open(outputfile, "a+");
        
        public static object fileHandler = open(inputfile, "r");
        
        public static object listOfLines = fileHandler.readlines();
        
        public static object split_array(object L, object n) {
            return (from i in Enumerable.Range(0, n)
                select L[i:n:]).ToList();
        }
        
        public static object threads = Convert.ToInt32(input("How many threads so you want to use? (Recommended 20): "));
        
        public static object threads = masscan.Count;
        
        public static object split = split_array(masscan, threads).ToList();
        
        public static object exitFlag = 0;
        
        public class myThread
            : threading.Thread {
            
            public myThread(object threadID, object name) {
                this.threadID = threadID;
                this.name = name;
            }
            
            public virtual object run() {
                Console.WriteLine("Starting Thread " + this.name);
                print_time(this.name);
                Console.WriteLine("Exiting Thread " + this.name);
            }
        }
        
        public static object print_time(object threadName) {
            foreach (var z in split[Convert.ToInt32(threadName)]) {
                if (exitFlag) {
                    threadName.exit();
                }
                try {
                    var ip = z;
                    var server = MinecraftServer(ip, 25565);
                    var status = server.status();
                } catch {
                    Console.WriteLine("Failed to get status of: " + ip);
                }
            }
        }
        
        public static object thread = myThread(x, x.ToString()).start();
    }
}
