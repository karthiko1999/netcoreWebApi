using Microsoft.EntityFrameworkCore;
using StudentManagement.Models.Domain;

namespace StudentManagement.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentManagement.Data.StudentDbContext> options) : base(options)
        {
            
        }

        public DbSet<Grade> Grades { get; set; } 
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<User_Role> Users_Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
           var grades = new List<Grade>()
           {
               new Grade()
                {
                    GradeId = Guid.NewGuid(),
                    GradeName = "5th Standard",
                    Section ="Asec"
                },
                new Grade()
                {
                    GradeId = Guid.NewGuid(),
                    GradeName = "6th Standard",
                    Section ="Bsec"
                },
                new Grade()
                {
                    GradeId = Guid.NewGuid(),
                    GradeName = "7th Standard",
                    Section ="Asec"
                }
           };

           var studentaddresses = new List<StudentAddress>(){
                new StudentAddress()
                {
                    StudentAddressId = Guid.NewGuid(),
                    Address = "2nd Mian 3rd Cross",
                    City ="Jagalur",
                    State ="Karnataka",
                    Country ="India"
                },
                new StudentAddress()
                {
                    StudentAddressId = Guid.NewGuid(),
                    Address = "3rd Mian 2nd Cross",
                    City ="Durga",
                    State ="Karnataka",
                    Country ="India"
                },
                new StudentAddress()
                {
                    StudentAddressId = Guid.NewGuid(),
                    Address = " 2nd Cross",
                    City ="Davangere",
                    State ="Karnataka",
                    Country ="India"
                }
           };

           var students = new List<Student>()
           {
               new Student()
                {
                    StudentID = Guid.NewGuid(),
                    StudentName = "Alex",
                    DateOfBirth = DateTime.Parse("11/09/1999"),
                    GradeId = (grades.Find(g=>g.GradeName == "5th Standard")).GradeId,
                    StudentAddressId = (studentaddresses.Find(g=>g.City == "Durga")).StudentAddressId
                },
                new Student()
                {
                    StudentID = Guid.NewGuid(),
                    StudentName = "Bob",
                    DateOfBirth = DateTime.Parse("09/09/1999"),
                    GradeId = (grades.Find(g=>g.GradeName == "6th Standard")).GradeId,
                    StudentAddressId = (studentaddresses.Find(g=>g.City == "Durga")).StudentAddressId
                },
                new Student()
                {
                    StudentID = Guid.NewGuid(),
                    StudentName = "Otto",
                    DateOfBirth = DateTime.Parse("01/02/1999"),
                    GradeId = (grades.Find(g=>g.GradeName == "7th Standard")).GradeId,
                    StudentAddressId = (studentaddresses.Find(g=>g.City == "Davangere")).StudentAddressId
                }

            };
            // This is to Configure the Foregin Key 
            modelbuilder.Entity<Student>()
                         .HasOne(x => x.Grade)
                         .WithMany(x=>x.Students)
                         .HasForeignKey(x=>x.GradeId);

            modelbuilder.Entity<Student>()
                         .HasOne(x => x.Address)
                         .WithMany(x=>x.Students)
                         .HasForeignKey(x=>x.StudentAddressId);

            modelbuilder.Entity<Grade>().HasData(grades);
            modelbuilder.Entity<StudentAddress>().HasData(studentaddresses);
            modelbuilder.Entity<Student>().HasData(students);
           
        //    var staticUsers = new List<User>(){
        //        new User(){
        //            Id = Guid.Parse("abb1561a-b9e9-4e1b-b89c-362c14c24ff1"),
        //            UserName = "readonly@user.com", 
        //            FirstName = "Read", 
        //            LastName = "Only", 
        //            EmailAddress = "readonly@user",
        //            Password = "ReadOnly@user123",
        //        },
        //        new User(){
        //            Id = Guid.Parse("ebad0f8c-aa01-4c06-8467-d5a892fe212f"),
        //            UserName = "readwrite@user.com", 
        //            FirstName = "Read", 
        //            LastName = "Write", 
        //            EmailAddress = "readwrite@user",
        //            Password = "ReadWrite@user123",
        //        }
        //    };
        //    var staticRoles = new List<Role>()
        //    {
        //        new Role(){
        //            Id = Guid.Parse("b7717016-1bdf-475d-9916-eb8bb22769d3"),
        //            Name = "reader",
        //        },
        //        new Role(){
        //            Id = Guid.Parse("663ec6c3-e369-47e6-87c5-1ccb8b7dfa33"),
        //            Name = "writer",
        //        }

        //    };
        //    var staticUserRole = new List<User_Role>()
        //     {
        //         new User_Role(){
        //             Id = Guid.Parse("7c2d51cb-c878-49a6-8392-f5ee28bd3602"),
        //             RoleId = Guid.Parse("abb1561a-b9e9-4e1b-b89c-362c14c24ff1"),
        //             UserId = Guid.Parse("b7717016-1bdf-475d-9916-eb8bb22769d3")
        //         },
        //          new User_Role(){
        //             Id = Guid.Parse("13cbebb1-5f80-43c5-a7af-292e05e62956"),
        //             RoleId = Guid.Parse("ebad0f8c-aa01-4c06-8467-d5a892fe212f"),
        //             UserId = Guid.Parse("663ec6c3-e369-47e6-87c5-1ccb8b7dfa33")
        //         },
        //          new User_Role(){
        //             Id = Guid.Parse("c1d8925c-aa2f-404e-af23-e5a6f1774c8f"),
        //             RoleId = Guid.Parse("ebad0f8c-aa01-4c06-8467-d5a892fe212f"),
        //             UserId = Guid.Parse("b7717016-1bdf-475d-9916-eb8bb22769d3")
        //         }  
        //     };

        //     modelbuilder.Entity<User>().HasData(staticUsers);
        //     modelbuilder.Entity<Role>().HasData(staticRoles);
        //     modelbuilder.Entity<User_Role>().HasData(staticUserRole);
       
            
            // This is to Configure the Foregin Key 
            modelbuilder.Entity<User_Role>()
                .HasOne(x => x.user)
                .WithMany(y => y.userRoles)
                .HasForeignKey(x=>x.UserId);


            modelbuilder.Entity<User_Role>()
                .HasOne(x => x.role)
                .WithMany(y => y.roleUsers)
                .HasForeignKey(x=>x.RoleId);

             base.OnModelCreating(modelbuilder);
        }    
        
    }
}