namespace GSMSMSExampleConsoleApplication
{
     class GSMcom
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public GSMcom()
        {

        }

        override
        public string ToString()
        {
            return $"{Description} {Name}";
        }
    }
}