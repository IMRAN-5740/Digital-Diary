using Digital.Diary.Models.EntityModels.Academic;
using Digital.Diary.Models.EntityModels.Administration.Associations;
using Digital.Diary.Models.EntityModels.Administration.Committees;
using Digital.Diary.Models.EntityModels.Administration.Offices;
using Digital.Diary.Models.EntityModels.Administration.Transportation;
using Digital.Diary.Models.EntityModels.Common;
using Digital.Diary.Models.EntityModels.Emergency_Services;
using Digital.Diary.Models.EntityModels.Miscellaneous;
using Digital.Diary.Models.EntityModels.Student_Activities.Clubs;
using Microsoft.EntityFrameworkCore;

namespace Digital.Diary.Databases.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        #region Academic

        public DbSet<CrTable> CrTables { get; set; }
        public DbSet<Dean> Deans { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Council> Councils { get; set; }
        public DbSet<RegentBoard> RegentBoards { get; set; }

        #endregion Academic

        #region Administration

        public DbSet<Association> Offices { get; set; }
        public DbSet<AssociationEmployee> OfficeEmployees { get; set; }

        public DbSet<Committee> Committees { get; set; }
        public DbSet<CommitteeEmployee> CommitteeEmployees { get; set; }

        public DbSet<Association> Associations { get; set; }
        public DbSet<AssociationEmployee> AssociationEmployees { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<TransportEmployee> TransportEmployees { get; set; }

        #endregion Administration

        #region CommonEntity

        public DbSet<Designation> Designations { get; set; }

        #endregion CommonEntity

        #region Miscellaneous

        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankEmployee> BankEmployees { get; set; }

        #endregion Miscellaneous

        #region EmergencyServices

        public DbSet<Ambulance> Ambulances { get; set; }
        public DbSet<AnsarForce> AnsarForces { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<FireStation> FireStations { get; set; }
        public DbSet<GuestHouse> Houses { get; set; }
        public DbSet<Journalist> Journalists { get; set; }
        public DbSet<PoliceStation> PoliceStations { get; set; }
        public DbSet<PostOffice> PostOffices { get; set; }
        public DbSet<Train> Trains { get; set; }

        #endregion EmergencyServices

        #region StudentActivities

        public DbSet<Club> Clubs { get; set; }
        public DbSet<ClubEmployee> ClubEmployees { get; set; }

        #endregion StudentActivities

        public DbSet<TeacherFaculty> TeachersFaculty { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define relationships and constraints

            // Teacher to Designation (Many-to-One)
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Designation)
                .WithMany()
                .HasForeignKey(t => t.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Teacher to Faculty(Many - to - One)
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Faculty)
                .WithMany(f => f.Teachers)
                .HasForeignKey(t => t.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Teacher to Department (Many-to-One)
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Department)
                .WithMany(d => d.Teachers)
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Department to Faculty (One-to-One or Many-to-One, based on your design)
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Faculty)
                .WithMany(f => f.Departments)
                .HasForeignKey(d => d.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Dean to Faculty (Many-to-One)
            modelBuilder.Entity<Dean>()
                .HasOne(d => d.Faculty)
                .WithMany(f => f.Deans)
                .HasForeignKey(d => d.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Dean to Designation (Many-to-One)
            modelBuilder.Entity<Dean>()
                .HasOne(d => d.Designation)
                .WithMany()
                .HasForeignKey(d => d.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);


            // CrTable to Department (Many-to-One)
            modelBuilder.Entity<CrTable>()
                .HasOne(cr => cr.Department)
                .WithMany(d => d.CrTables)
                .HasForeignKey(cr => cr.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Staff to Designation (Many-to-One)
            modelBuilder.Entity<Staff>()
                .HasOne(s => s.Designation)
                .WithMany()
                .HasForeignKey(s => s.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Staff to Department (Many-to-One)
            modelBuilder.Entity<Staff>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Staffs)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Council to Designation (Many-to-One)
            modelBuilder.Entity<Council>()
               .HasOne(c => c.Designation)
               .WithMany()
               .HasForeignKey(c => c.DesignationId)
               .OnDelete(DeleteBehavior.Restrict);

            // RegentBoard to Designation (Many-to-One)
            modelBuilder.Entity<RegentBoard>()
               .HasOne(c => c.Designation)
               .WithMany()
               .HasForeignKey(c => c.DesignationId)
               .OnDelete(DeleteBehavior.Restrict);

            // OfficeEmployee to Office (Many-to-One)

            modelBuilder.Entity<OfficeEmployee>()
              .HasOne(c => c.Office)
              .WithMany()
              .HasForeignKey(c => c.OfficeId)
              .OnDelete(DeleteBehavior.Restrict);

            // Office to OfficeEmployee (One-to-Many)

            modelBuilder.Entity<Office>()
               .HasMany(o => o.OfficeEmployees)
               .WithOne(oe => oe.Office)
               .HasForeignKey(oe => oe.OfficeId)
               .OnDelete(DeleteBehavior.Cascade);

            // OfficeEmployee to Designation (Many-to-One)
            modelBuilder.Entity<OfficeEmployee>()
                .HasOne(s => s.Designation)
                .WithMany()
                .HasForeignKey(s => s.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            // CommitteeEmployee to Committee (Many-to-One)

            modelBuilder.Entity<CommitteeEmployee>()
              .HasOne(c => c.Committee)
              .WithMany()
              .HasForeignKey(c => c.CommitteeId)
              .OnDelete(DeleteBehavior.Restrict);

            // Committee toCommitteeEmployee (One-to-Many)

            modelBuilder.Entity<Committee>()
               .HasMany(o => o.CommitteeEmployees)
               .WithOne(oe => oe.Committee)
               .HasForeignKey(oe => oe.CommitteeId)
               .OnDelete(DeleteBehavior.Cascade);

            // CommitteeEmployee to Designation (Many-to-One)
            modelBuilder.Entity<CommitteeEmployee>()
                .HasOne(s => s.Designation)
                .WithMany()
                .HasForeignKey(s => s.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            // AssociationEmployee to Association (Many-to-One)

            modelBuilder.Entity<AssociationEmployee>()
              .HasOne(c => c.Association)
              .WithMany()
              .HasForeignKey(c => c.AssociationId)
              .OnDelete(DeleteBehavior.Restrict);

            // Association to AssociationEmployee (One-to-Many)

            modelBuilder.Entity<Association>()
               .HasMany(o => o.AssociationEmployees)
               .WithOne(oe => oe.Association)
               .HasForeignKey(oe => oe.AssociationId)
               .OnDelete(DeleteBehavior.Cascade);

            // AssociationEmployee to Designation (Many-to-One)
            modelBuilder.Entity<AssociationEmployee>()
                .HasOne(s => s.Designation)
                .WithMany()
                .HasForeignKey(s => s.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            // TransportEmployee to Transport (Many-to-One)

            modelBuilder.Entity<TransportEmployee>()
              .HasOne(c => c.Transport)
              .WithMany()
              .HasForeignKey(c => c.TransportId)
              .OnDelete(DeleteBehavior.Restrict);

            // Transport to TransportEmployee (One-to-Many)

            modelBuilder.Entity<Transport>()
               .HasMany(o => o.TransportEmployees)
               .WithOne(oe => oe.Transport)
               .HasForeignKey(oe => oe.TransportId)
               .OnDelete(DeleteBehavior.Cascade);

            // TransportEmployee to Designation (Many-to-One)
            modelBuilder.Entity<TransportEmployee>()
                .HasOne(s => s.Designation)
                .WithMany()
                .HasForeignKey(s => s.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            // BankEmployee to Bank (Many-to-One)

            modelBuilder.Entity<BankEmployee>()
              .HasOne(c => c.Bank)
              .WithMany()
              .HasForeignKey(c => c.BankId)
              .OnDelete(DeleteBehavior.Restrict);

            // Bank to BankEmployee (One-to-Many)

            modelBuilder.Entity<Bank>()
               .HasMany(o => o.BankEmployees)
               .WithOne(oe => oe.Bank)
               .HasForeignKey(oe => oe.BankId)
               .OnDelete(DeleteBehavior.Cascade);

            // BankEmployee to Designation (Many-to-One)
            modelBuilder.Entity<BankEmployee>()
                .HasOne(s => s.Designation)
                .WithMany()
                .HasForeignKey(s => s.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            // ClubEmployee to Club (Many-to-One)

            modelBuilder.Entity<ClubEmployee>()
              .HasOne(c => c.Club)
              .WithMany()
              .HasForeignKey(c => c.ClubId)
              .OnDelete(DeleteBehavior.Restrict);

            // Club to ClubEmployee (One-to-Many)

            modelBuilder.Entity<Club>()
               .HasMany(o => o.ClubEmployees)
               .WithOne(oe => oe.Club)
               .HasForeignKey(oe => oe.ClubId)
               .OnDelete(DeleteBehavior.Cascade);

            // ClubEmployee to Designation (Many-to-One)
            modelBuilder.Entity<ClubEmployee>()
                .HasOne(s => s.Designation)
                .WithMany()
                .HasForeignKey(s => s.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Police Station to Designation (Many-to-One)
            modelBuilder.Entity<PoliceStation>()
                .HasOne(t => t.Designation)
                .WithMany()
                .HasForeignKey(t => t.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Post Office to Designation (Many-to-One)
            modelBuilder.Entity<PostOffice>()
                .HasOne(t => t.Designation)
                .WithMany()
                .HasForeignKey(t => t.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Other configurations...

            // Adjust cascade behaviors as needed
        }
    }
}