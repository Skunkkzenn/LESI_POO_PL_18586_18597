using System;
using System.Collections.Generic;
using System.Globalization;

namespace Safari_Management
{
    class Seguranca
    {

        public int SID { get; set; }
        public string Name { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Equipment {  get; set; }
        public string Section { get; set; }
        public string Processes { get; set; }
        public string EmergencyNumbers { get; set; }

        public Seguranca() { }

        public Seguranca(int sid, string name, DateTime dateofbirth, string equipment, string section, string processes, string emergencynumbers)
        {

            SID = sid;
            Name = name;
            DateofBirth = dateofbirth;
            Equipment = equipment;
            Section = section;
            Processes = processes;
            EmergencyNumbers = emergencynumbers;

        }

        public int RegisterSecurity(int numOfreg, List<Seguranca> segurancaList)
        {
            return segurancaList.Count;
        }

        public void SaveSecurityToFile(List<Seguranca> segurancaList, string fileName)
        {

        }

        public List<Seguranca> ReadSecurityFromFile(string fileName)
        {
            return null;
        }

        public void AssignSectorAgent(int sid, string section)
        {
         
        }

        public void DefineEmergencyProcedures(string processes)
        {
          
        }

        public void ReportEmergency(string emergencynumbers)
        {
         
        }

    }
}
