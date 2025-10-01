namespace EF_Core
{
    class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal salary { get; set; }
        public int? age { get; set; }


        public override string ToString()
        {
            return $"id = {id},\nname = {name},\nsalary = {salary},\nage = {(age == null ? "not provided" : age.ToString())}";
        }

    }
}
