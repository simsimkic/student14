using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Controller.ControllerAppointment;
using Controller.ControllerBlog;
using Controller.ControllerDean;
using Controller.ControllerDoctor;
using Controller.ControllerMedicalDocumentation;
using Controller.ControllerPatient;
using Controller.ControllerRoom;
using Controller.ControllerSecretary;
using Controller.ControllerUser;
using Main.ConsoleApplication;
using Main.Controller.ControllerDean;
using Main.Repository.RepositoryUser;
using Main.View;
using Model.DoctorModel;
using Repository;
using Repository.RepositoryAppointment;
using Repository.RepositoryBlog;
using Repository.RepositoryDean;
using Repository.RepositoryDoctor;
using Repository.RepositoryMedicalDocumentation;
using Repository.RepositoryPatient;
using Repository.RepositoryReport;
using Repository.RepositoryRoom;
using Repository.RepositorySecretary;
using Repository.RepositoryUser;
using Service.ServiceAppointment;
using Service.ServiceBlog;
using Service.ServiceDean;
using Service.ServiceDoctor;
using Service.ServiceMedicalDocumentation;
using Service.ServicePatient;
using Service.ServiceRoom;
using Service.ServiceSecretary;
using Service.ServiceUser;

namespace Main
{
    class Program
    {
        // NOTE(Jovan): Dean repo/service/controller
        public static DrugRepository drugRepo = new DrugRepository();
        public static ApprovalRepository approvalRepo = new ApprovalRepository(drugRepo);
        public static DeanRepository deanRepo = new DeanRepository();
        public static ItemRepository itemRepo = new ItemRepository();
        public static ExamRoomRepository examRoomRepo = new ExamRoomRepository();
        public static OperationRoomRepository opRoomRepo = new OperationRoomRepository();
        public static RecoveryRoomRepository recRoomRepo = new RecoveryRoomRepository();
        public static StorageRepository storageRepo = new StorageRepository(itemRepo, drugRepo);
        public static ScheduleReportRepository scheduleReportRepo = new ScheduleReportRepository();

        public static ExaminationService examinationService = new ExaminationService(new ExaminationRepository(), new OperationRepository(), new DoctorRepository());
        public static OperationService operationService = new OperationService(new OperationRepository());
        public static DrugServices drugServices = new DrugServices(drugRepo);
        public static ApprovalServices approvalServices = new ApprovalServices(approvalRepo, drugServices);
        public static ExamRoomService examRoomService = new ExamRoomService(examRoomRepo);
        public static OperatingRoomService operatingRoomService = new OperatingRoomService(opRoomRepo);
        public static RecoveryRoomService recRoomService = new RecoveryRoomService(recRoomRepo);
        public static StorageService storageService = new StorageService(storageRepo);
        public static ItemServices itemServices = new ItemServices(recRoomService, operatingRoomService, examRoomService, storageService, itemRepo);
        public static DeanReportServices deanReportServices = new DeanReportServices(scheduleReportRepo, examinationService, operationService);
        public static StaffServices staffServices = new StaffServices(new DoctorRepository(), new SecretaryRepository());

        public static ApprovalController approvalController = new ApprovalController(approvalServices);
        public static DeanReportController deanReportController = new DeanReportController(deanReportServices);
        public static DrugController drugController = new DrugController(drugServices);
        public static ItemController itemController = new ItemController(itemServices);
        public static StaffController staffController = new StaffController(staffServices);
        public static ExamRoomController examRoomController = new ExamRoomController(examRoomService);
        public static OperationRoomController operationRoomController = new OperationRoomController(operatingRoomService);
        public static RecoveryRoomController recoveryRoomController = new RecoveryRoomController(recRoomService);
        public static StorageController storageController = new StorageController(storageService);
        static int Menu()
        {
            int Result = 0;
            Console.WriteLine("====Glavni meni:====");
            Console.WriteLine("\t1. Debug stuff");
            Console.WriteLine("\t2. Dean");
            Console.WriteLine("\t3. Doctor");
            Console.WriteLine("\t4. Patient");
            Console.WriteLine("\t5. Secretary");
            Console.WriteLine("\t0. Exit");
            Console.WriteLine("Odaberite opciju:");
            while (!Int32.TryParse(Console.ReadLine(), out Result))
            {
                Console.WriteLine("Unos mora biti ceo broj!");
            }
            return Result;
        }

        static void Debug()
        {
            City city = new City("Kekenda", 21000);
            State state = new State("Vodzvodina");
            Address address = new Address("Legijina", 1);
            Location location = new Location(state, city, address);

            Account account = new Account("pera", "pera");
            Account acc2 = new Account("kris", "kris");
            RegisteredUser registeredUser = new RegisteredUser(account, "Pera", "Peric", "123141", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Perica", city, location);

            PatientChart patientChart = new PatientChart();

            Secretary secretary1 = new Secretary(null, account, "Pera", "Peric", "123141", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Perica", city, location);
            Secretary secretary2 = new Secretary(null, account, "Pera", "Peric", "888141", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Perica", city, location);
            Secretary secretary3 = new Secretary(null, acc2, "Pera", "Peric", "43534543", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Perica", city, location);
            SecretaryRepository sr = new SecretaryRepository();
            sr.Create(secretary1);
            sr.Create(secretary2);
            sr.Create(secretary3);

            SecretaryController sc = new SecretaryController(new SecretaryService(new SecretaryRepository(), new NotificationRepository()));
            Console.WriteLine(sc.DoesSecretaryExist("asd", "kris"));
            /*
            List<Secretary> sec = sr.GetAll();

            foreach (Secretary s in sec)
            {
                Console.WriteLine(s.Pin);
            }

            */
            //Doctor doc = new Doctor("orl", new ExamRoom(), new OperatingRoom(), acc2, "Kris", "Peric", "123141", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Perica", city, location);

            //RegisteredPatient pacijent = new RegisteredPatient(doc, patientChart, acc2, "Pera", "Peric", "123141", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Perica", city, location);

            //Console.WriteLine(pacijent.Name);
            //Console.WriteLine(doc.Name);
            //Console.WriteLine(pacijent.Doctor.Name);


            /* Feedback content1 = new Feedback(new RegisteredUser(null, null, null, "1", DateTime.Now, null, null, null, null, null), "1", "pijhboibhilouibouygouhbohbuo", DateTime.Today);
             Feedback content2 = new Feedback(new RegisteredUser(null, null, null, "2", DateTime.Now, null, null, null, null, null), "2", "aopsjf", DateTime.Today);
             Feedback content3 = new Feedback(new RegisteredUser(null, null, null, "3", DateTime.Now, null, null, null, null, null), "3", "ao;sdgjn", DateTime.Today);
             Feedback content4 = new Feedback(new RegisteredUser(null, null, null, "4", DateTime.Now, null, null, null, null, null), "4", "Mojašđžćшђжћч", DateTime.Today);
             Feedback content5 = new Feedback(new RegisteredUser(null, null, null, "4", DateTime.Now, null, null, null, null, null), "5", "N", DateTime.Today);
             Feedback content6 = new Feedback(new RegisteredUser(null, null, null, "4", DateTime.Now, null, null, null, null, null), "6", "I", DateTime.Today);
             Feedback content7 = new Feedback(new RegisteredUser(null, null, null, "4", DateTime.Now, null, null, null, null, null), "7", "N", DateTime.Today);
             Feedback content8 = new Feedback(new RegisteredUser(null, null, null, "4", DateTime.Now, null, null, null, null, null), "8", "A", DateTime.Today);

             List<Feedback> contents = new List<Feedback>();
             contents.Add(content1);
             contents.Add(content2);
             contents.Add(content3);
             contents.Add(content4);
             contents.Add(content5);
             contents.Add(content6);
             contents.Add(content7);
             contents.Add(content8);

             FeedbackRepository fr = new FeedbackRepository();
             fr.SaveAll(contents);


             List<Feedback> contentsGetAll = fr.GetAllUsersFeedbacks("4");
             Console.WriteLine("-------");
             Console.WriteLine(contentsGetAll.Count);
             Console.WriteLine("-------");

             foreach (Feedback c in contentsGetAll)
             {
                 Console.WriteLine(c.Text);
             }

             fr.Create(content4);

             contentsGetAll = fr.GetAll();
             Console.WriteLine(contentsGetAll.Count);
             foreach (Content c in contentsGetAll)
             {
                 Console.WriteLine(c.Id);
             }

             //fr.UpdateItem(contentToUpdate);
             contentsGetAll = fr.GetAll();
             Console.WriteLine(contentsGetAll.Count);
             foreach (Content c in contentsGetAll)
             {
                 Console.WriteLine(c.Text);
             }

             fr.Delete("1");

             contentsGetAll = fr.GetAll();
             //Console.WriteLine(contentsGetAll.Count);
             foreach (Content c in contentsGetAll)
             {
                 Console.WriteLine(c.Id);
             }

             Content cont = fr.Get("2");
             Console.WriteLine(cont.Text);





             Notification not1 = new Notification(new RegisteredUser("1"),"1", "pijhboibhilouibouygouhbohbuo", DateTime.Today);
             Notification not2 = new Notification(new RegisteredUser("2"),"2", "aopsjf", DateTime.Today);
             Notification not3 = new Notification(new RegisteredUser("3"),"3", "ao;sdgjn", DateTime.Today);
             Notification not4 = new Notification(new RegisteredUser("4"),"4", "PERAAFS", DateTime.Today);
             Notification not5 = new Notification(new RegisteredUser("5"), "5", "NOVA NOTIFIKACIJA", DateTime.Today);
             Notification not6 = new Notification(new RegisteredUser("5"), "6", "NOVA NOTIFIKACIJA", DateTime.Today);
             Notification not7 = new Notification(new RegisteredUser("5"), "7", "NOVA NOTIFIKACIJA", DateTime.Today);
             Notification not8 = new Notification(new RegisteredUser("5"), "8", "NOVA NOTIFIKACIJA", DateTime.Today);

             List<Notification> notifications = new List<Notification>();
             notifications.Add(not1);
             notifications.Add(not2);
             notifications.Add(not3);
             notifications.Add(not4);
             //RegisteredUser registeredUserPera = new RegisteredUser(account, contents , notifications  , "Pera", "Peric", "123141", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Perica", city, location);
             RegisteredUser registeredUserPera = new RegisteredUser(account, "Pera", "Peric", "123141", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Perica", city, location);
             */
            // Doctor doc = new Doctor("orl", null, null, acc2, "Kris", "Peric", "123141", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Perica", city, location);
            //RegisteredPatient pacijentPera = new RegisteredPatient(null, null, acc2,"Pera", "Peric", "123141", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Perica", city, location);
            //List<RegisteredPatient> registeredPatients = new List<RegisteredPatient>();
            //registeredPatients.Add(pacijentPera);


            //RegisteredPatientRepository rpr = new RegisteredPatientRepository();
            //rpr.SaveAll(registeredPatients);


            /*AllTermsInADay a = new AllTermsInADay();
            foreach (Term t in a.Term) {
                Console.WriteLine(t.Start + " " + t.End);
            }*/

            //EXAMS I FREE TERMS
            /*
            Examination exam1 = new Examination(null, false, "864315", AppointmentType.examination, null, new Term(DateTime.Today.AddHours(7).AddMinutes(0), DateTime.Today.AddHours(7).AddMinutes(30)), doc, DateTime.Today.Date);
            Examination exam2 = new Examination(null, false, "463155", AppointmentType.examination, null, new Term(DateTime.Today.AddHours(8).AddMinutes(0), DateTime.Today.AddHours(8).AddMinutes(30)), doc, DateTime.Today.Date);
            Examination exam3 = new Examination(null, false, "282652", AppointmentType.examination, null, new Term(DateTime.Today.AddHours(8).AddMinutes(30), DateTime.Today.AddHours(9).AddMinutes(0)), doc, DateTime.Today.Date);

            ExaminationController examinationController = new ExaminationController(new Service.ServiceAppointment.ExaminationService(new AppointmentRepository()));
            examinationController.ScheduleExam(exam1);
            examinationController.ScheduleExam(exam2);
            examinationController.ScheduleExam(exam3);

            AppointmentController appointmentController = new AppointmentController(new Service.ServiceAppointment.AppointmentService(new AppointmentRepository()));
            List<Term> terms = appointmentController.GetAllDoctorsFreeTermsForToday(doc);

            foreach (Term t in terms) {
                Console.WriteLine(t.Start + " " + t.End);
            }
            
            */
            Console.WriteLine("--------------");
            //nc.NewNotification(not5);

            /*
            List<Notification> notifs = nr.GetAllItems();
            foreach (Notification notif in notifs)
            {
                Console.WriteLine(notif.Text);
            }
            */


            Console.WriteLine("(ALEKSANDAR) Load: ");
            Console.WriteLine("1 --------- LoadPatients/Doctors/Medical documentations");
            Console.WriteLine("2 --------- LoadBlog");
            Console.WriteLine("3 --------- LoadRatings/Notifs");
            Console.WriteLine("4 --------- LoadPatientsExams");
            int i = int.Parse(Console.ReadLine());
            switch (i)
            {
                case 1: LoadPatientsDoctorsMedicalDocumentation();
                    break;
                case 2: LoadBlog();
                    break;
                case 3: LoadRatings();
                    break;
                case 4: LoadExams();
                    break;

                default:
                    break;
            }

            //BlogShit();
            //RatingShit();
            //AccountShit();
            //FeedbackShit();
            Console.ReadLine();


        }
        static void LoadExams()
        {
            AppointmentService appointmentService = new AppointmentService(new OperationRepository(), new ExaminationRepository(), new DoctorRepository());
            DoctorController doctorController = new DoctorController(new DoctorService(new DoctorRepository()));
            
            foreach(Doctor doctor in doctorController.GetAllDoctors())
            {
               foreach(Term term in appointmentService.GetDoctorsTermsForShift(doctor, new DateTime(2020, 7, 1)))
                {
                    Console.WriteLine(term.Start);
                    Console.WriteLine(term.End);
                    Console.WriteLine("-------");
                }
            }
            

            AppointmentController appointmentController = new AppointmentController(new AppointmentService(new OperationRepository(), new ExaminationRepository(), new DoctorRepository()));
            RegisteredPatientController registeredPatientController = new RegisteredPatientController(new RegisteredPatientService(new RegisteredPatientRepository(), new RegisteredUserRepository(), new PatientChartRepository()));

            List<RegisteredPatient> patients = registeredPatientController.GetAll();
            List<Doctor> doctors = doctorController.GetAllDoctors();

            Room examRoom1 = new Room("roomId1", "202", false, RoomType.EXAMROOM);
            Room examRoom2 = new Room("roomId2", "203", false, RoomType.EXAMROOM);
            Room examRoom3 = new Room("roomId3", "204", false, RoomType.EXAMROOM);
            examRoomController.AddRoom(examRoom1);
            examRoomController.AddRoom(examRoom2);
            examRoomController.AddRoom(examRoom3);

            Room operRoom1 = new Room("operId1", "OS1", false, RoomType.OPERATINGROOM);
            Room operRoom2 = new Room("operId2", "OS2", false, RoomType.OPERATINGROOM);
            Room operRoom3 = new Room("operId3", "OS3", false, RoomType.OPERATINGROOM);

            Examination exam1 = new Examination(examRoom1, false, "864315", AppointmentType.EXAMINATION, patients[0], new Term(new DateTime(2020, 7, 1, 7, 00, 0), new DateTime(2020, 7, 1, 7, 30, 0)), doctors[0], new DateTime(2020,7,1,0,0,0));
            Examination exam2 = new Examination(examRoom1, false, "684651", AppointmentType.EXAMINATION, patients[1], new Term(new DateTime(2020, 7, 1, 7, 30, 0), new DateTime(2020, 7, 1, 8, 0, 0)), doctors[0], new DateTime(2020, 7, 1, 0, 0, 0));
            Examination exam3 = new Examination(examRoom1, false, "541545", AppointmentType.EXAMINATION, patients[2], new Term(new DateTime(2020, 7, 1, 9, 0, 0), new DateTime(2020, 7, 1, 9, 30, 0)), doctors[0], new DateTime(2020, 7, 1, 0, 0, 0));
            Examination exam4 = new Examination(examRoom2, false, "463155", AppointmentType.EXAMINATION, patients[1], new Term(new DateTime(2020, 7, 1, 8, 30, 0), new DateTime(2020, 7, 1, 9, 0, 0)), doctors[1], new DateTime(2020, 7, 1, 0, 0, 0));
            Examination exam5 = new Examination(examRoom3, false, "282652", AppointmentType.EXAMINATION, patients[2], new Term(new DateTime(2020, 7, 1, 13, 0, 0), new DateTime(2020, 7, 1, 13, 30, 0)), doctors[2], new DateTime(2020, 7, 1, 0, 0, 0));
            Examination exam6 = new Examination(examRoom3, false, "282657", AppointmentType.EXAMINATION, patients[2], new Term(new DateTime(2020, 7, 3, 8, 0, 0), new DateTime(2020, 7, 3, 8, 30, 0)), doctors[0], new DateTime(2020, 7, 3, 0, 0, 0));
            Examination exam7 = new Examination(examRoom1, false, "124986", AppointmentType.EXAMINATION, patients[1], new Term(new DateTime(2020, 7, 10, 7, 30, 0), new DateTime(2020, 7, 10, 8, 0, 0)), doctors[0], new DateTime(2020, 7, 10, 0, 0, 0));
            Examination exam8 = new Examination(examRoom1, false, "12124512", AppointmentType.EXAMINATION, patients[1], new Term(new DateTime(2020, 7, 11, 11, 30, 0), new DateTime(2020, 7, 11, 11, 30, 0)), doctors[0], new DateTime(2020, 7, 11, 0, 0, 0));
            Examination exam9 = new Examination(examRoom1, false, "12124514", AppointmentType.EXAMINATION, patients[1], new Term(new DateTime(2020, 7, 17, 17, 30, 0), new DateTime(2020, 7, 17, 18, 0, 0)), doctors[0], new DateTime(2020, 7, 17, 0, 0, 0));
            Examination exam10 = new Examination(examRoom1, false, "12124", AppointmentType.EXAMINATION, patients[1], new Term(new DateTime(2020, 7, 26, 13,30, 0), new DateTime(2020, 7, 26, 14, 0, 0)), doctors[0], new DateTime(2020, 7, 26, 0, 0, 0));

            Console.WriteLine(patients[0].Name + " " + patients[0].Surname);
            Console.WriteLine(patients[1].Name + " " + patients[1].Surname);

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("--------------------------------------------");
            ExaminationController examinationController = new ExaminationController(new ExaminationService(new ExaminationRepository(), new OperationRepository(), new DoctorRepository()));
            examinationController.ScheduleExam(exam1);
            examinationController.ScheduleExam(exam2);
            examinationController.ScheduleExam(exam3);
            examinationController.ScheduleExam(exam4);
            examinationController.ScheduleExam(exam5);
            examinationController.ScheduleExam(exam6);
            examinationController.ScheduleExam(exam7);
            examinationController.ScheduleExam(exam8);
            examinationController.ScheduleExam(exam9);
            examinationController.ScheduleExam(exam10);

            OperationController operationController = new OperationController(new OperationService(new OperationRepository()));
            Operation oper1 = new Operation(operRoom2, false, "6516511", AppointmentType.OPERATION, patients[2], new Term(new DateTime(2020, 7, 5, 9, 0, 0), new DateTime(2020, 7, 5, 12, 0, 0)), doctors[1], new DateTime(2020, 7, 5, 0, 0, 0));
            Operation oper2 = new Operation(operRoom2, false, "9892513", AppointmentType.OPERATION, patients[1], new Term(new DateTime(2020, 7, 6, 9, 0, 0), new DateTime(2020, 7, 6, 12, 0, 0)), doctors[1], new DateTime(2020, 7, 6, 0, 0, 0));
            operationController.ScheduleOperation(oper1);
            operationController.ScheduleOperation(oper2);

            Examination exam11 = new Examination(examRoom1, false, "85345374", AppointmentType.EXAMINATION, patients[2], new Term(DateTime.Today.AddHours(7).AddMinutes(0), DateTime.Today.AddHours(7).AddMinutes(30)), doctors[0], DateTime.Today.Date);
            Examination exam12 = new Examination(examRoom1, false, "5345343", AppointmentType.EXAMINATION, patients[1], new Term(DateTime.Today.AddHours(7).AddMinutes(30), DateTime.Today.AddHours(8).AddMinutes(0)), doctors[0], DateTime.Today.Date);
            Examination exam13 = new Examination(examRoom1, false, "8735453", AppointmentType.EXAMINATION, patients[0], new Term(DateTime.Today.AddHours(8).AddMinutes(0), DateTime.Today.AddHours(8).AddMinutes(30)), doctors[0], DateTime.Today.Date);
            Examination exam14 = new Examination(examRoom2, false, "4534533", AppointmentType.EXAMINATION, patients[1], new Term(DateTime.Today.AddHours(8).AddMinutes(0), DateTime.Today.AddHours(8).AddMinutes(30)), doctors[1], DateTime.Today.Date);
            Examination exam15 = new Examination(examRoom3, false, "8254343", AppointmentType.EXAMINATION, patients[2], new Term(DateTime.Today.AddHours(15).AddMinutes(30), DateTime.Today.AddHours(16).AddMinutes(0)), doctors[2], DateTime.Today.Date);
            examinationController.ScheduleExam(exam11);
            examinationController.ScheduleExam(exam12);
            examinationController.ScheduleExam(exam13);
            examinationController.ScheduleExam(exam14);
            examinationController.ScheduleExam(exam15);




            foreach (Term term in appointmentService.GetAllDoctorsFreeTermsForDate(doctors[0], new DateTime(2020, 7, 1)))
            {
                Console.WriteLine(term.Start);
                Console.WriteLine(term.End);
                Console.WriteLine("-------");
            }

            foreach (Term term in appointmentService.GetAllDoctorsFreeTermsForTimePeriod(new DateTime(2020,7,1), new DateTime(2020, 7, 3),doctors[0]))
            {
                Console.WriteLine(term.Start);
                Console.WriteLine(term.End);
                Console.WriteLine("-------");
            }


        }
        static void DoctorOptions()
        {
            /*DoctorController doctorController = new DoctorController(new Service.ServiceDoctor.DoctorService(new DoctorRepository()));

            City city = new City("Novi Sad", 21000);
            State state = new State("Serbia");
            Address address = new Address("Balzakova", 1);
            Location location = new Location(state, city, address);

            Account account1 = new Account("pera", "pera"); 
            Account account2 = new Account("kris", "kris");
            Account account3 = new Account("mika", "mika");
            RegisteredUser registeredUser1 = new RegisteredUser(account1, "Pera", "Peric", "123141", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Perica", city, location);
            RegisteredUser registeredUser2 = new RegisteredUser(account2, "Mika", "Mikic", "651651", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Perica", city, location);
            RegisteredUser registeredUser3 = new RegisteredUser(account3, "Iva", "Ivic", "654684", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Perica", city, location);


            Room examRoom1 = new Room("roomId1", "202", false, RoomType.EXAMROOM);
            Room examRoom2 = new Room("roomId2", "203", false, RoomType.EXAMROOM);
            Room examRoom3 = new Room("roomId3", "204", false, RoomType.EXAMROOM);

            Room operRoom1 = new Room("operId1", "202", false, RoomType.OPERATINGROOM);
            Room operRoom2 = new Room("operId2", "202", false, RoomType.OPERATINGROOM);
            Room operRoom3 = new Room("operId3", "202", false, RoomType.OPERATINGROOM);

            Doctor doctor1 = new Doctor("ORL", examRoom1, operRoom1, account1, "Ivan", "Ivanic", "516511", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Perica", city, location);
            Doctor doctor2 = new Doctor("KARDIOLOG", examRoom2, operRoom2, account2, "Jova", "Jovic", "686815", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Perica", city, location);
            Doctor doctor3 = new Doctor("NEUROLOG", examRoom3, operRoom3, account3, "Ana", "Anic", "782527", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Perica", city, location);

            RegisteredPatient registeredPatient1 = new RegisteredPatient(doctor1, registeredUser1);
            RegisteredPatient registeredPatient2 = new RegisteredPatient(doctor2, registeredUser2);
            RegisteredPatient registeredPatient3 = new RegisteredPatient(doctor3, registeredUser3);

            RegisteredPatientController registeredPatientController = new RegisteredPatientController(new RegisteredPatientService(new RegisteredPatientRepository(), new TherapyRepository(), new RegisteredUserRepository(), new PatientChartRepository()));
            registeredPatientController.NewRegisteredPatient(registeredPatient1);
            registeredPatientController.NewRegisteredPatient(registeredPatient2);
            registeredPatientController.NewRegisteredPatient(registeredPatient3);


            PatientChart patientChart1 = new PatientChart("354", registeredPatient1);
            PatientChart patientChart2 = new PatientChart("511", registeredPatient2);
            PatientChart patientChart3 = new PatientChart("684", registeredPatient3);

            PatientChartController patientChartController = new PatientChartController(new Service.ServiceMedicalDocumentation.PatientChartService(new PatientChartRepository()));
            patientChartController.NewPatientChart(patientChart1);
            patientChartController.NewPatientChart(patientChart2);
            patientChartController.NewPatientChart(patientChart3);

            doctorController.NewDoctor(doctor1);
            doctorController.NewDoctor(doctor2);
            doctorController.NewDoctor(doctor3);

            Examination exam1 = new Examination(examRoom1, false, "864315", AppointmentType.EXAMINATION, registeredPatient1, new Term(DateTime.Today.AddHours(7).AddMinutes(0), DateTime.Today.AddHours(7).AddMinutes(30)), doctor1, DateTime.Today.Date);
            Examination exam2 = new Examination(examRoom1, false, "684651", AppointmentType.EXAMINATION, registeredPatient2, new Term(DateTime.Today.AddHours(7).AddMinutes(30), DateTime.Today.AddHours(8).AddMinutes(0)), doctor1, DateTime.Today.Date);
            Examination exam3 = new Examination(examRoom1, false, "541545", AppointmentType.EXAMINATION, registeredPatient3, new Term(DateTime.Today.AddHours(8).AddMinutes(0), DateTime.Today.AddHours(8).AddMinutes(30)), doctor1, DateTime.Today.Date);
            Examination exam4 = new Examination(examRoom1, false, "463155", AppointmentType.EXAMINATION, registeredPatient2, new Term(DateTime.Today.AddHours(8).AddMinutes(0), DateTime.Today.AddHours(8).AddMinutes(30)), doctor2, DateTime.Today.Date);
            Examination exam5 = new Examination(examRoom1, false, "282652", AppointmentType.EXAMINATION, registeredPatient3, new Term(DateTime.Today.AddHours(15).AddMinutes(30), DateTime.Today.AddHours(16).AddMinutes(0)), doctor3, DateTime.Today.Date);


            ExaminationController examinationController = new ExaminationController(new ExaminationService(new ExaminationRepository()));
            examinationController.ScheduleExam(exam1);
            examinationController.ScheduleExam(exam2);
            examinationController.ScheduleExam(exam3);
            examinationController.ScheduleExam(exam4);
            examinationController.ScheduleExam(exam5);
            /*

            Allergy a1 = new Allergy("615","Polen");
            Allergy a2 = new Allergy("584","Lesnik");
            patientChartController.AddAllergy(a1, patientChart1);
            patientChartController.AddAllergy(a2, patientChart1);
            patientChartController.AddAllergy(a1, patientChart2);
            patientChartController.AddAllergy(a2, patientChart2);
            patientChartController.AddAllergy(a1, patientChart3);
            patientChartController.AddAllergy(a2, patientChart3);
 

            Drug drug1 = new Drug("123");
            Drug drug2 = new Drug("321");
            Drug drug3 = new Drug("234");
            drug1.Name = "Brufen";
            drug2.Name = "Analgin";
            drug3.Name = "Xanax";

            DrugRepository drugRepository = new DrugRepository();
            drugRepository.Create(drug1);
            drugRepository.Create(drug2);
            drugRepository.Create(drug3);

            Prescription p1 = new Prescription("2 put dnevno", DateTime.Today.Date, "651", drug1, patientChart1);
            Prescription p2 = new Prescription("2 put dnevno", DateTime.Today.Date, "894", drug2, patientChart1);
            Prescription p3 = new Prescription("3 puta dnevno", DateTime.Today.Date, "655", drug2, patientChart2);

            PrescriptionController pr = new PrescriptionController(new Service.ServiceMedicalDocumentation.PrescriptionService(new PrescriptionRepository()));
            pr.WritePrescription(p1);
            pr.WritePrescription(p2);
            pr.WritePrescription(p3);

            ReferralLetterController refLetCont = new ReferralLetterController(new Service.ServiceMedicalDocumentation.ReferralLetterService(new ReferralLetterRepository()));

            ReferralLetter referralLetter1 = new ReferralLetter("Potreban dalji pregled", DateTime.Today, "2345", patientChart1, doctor1);
            ReferralLetter referralLetter2 = new ReferralLetter("Zabrinjavajuce psihicko stanje", DateTime.Today, "9481", patientChart1, doctor2);
            ReferralLetter referralLetter3 = new ReferralLetter("Potreban dalji pregled i laboratorijski nalaz", DateTime.Today, "8481", patientChart2, doctor1);
            refLetCont.WriteReferralLetter(referralLetter1);
            refLetCont.WriteReferralLetter(referralLetter2);
            refLetCont.WriteReferralLetter(referralLetter3);

            TherapyController therapyController = new TherapyController(new Service.ServiceMedicalDocumentation.TherapyService(new TherapyRepository()));

            PrescribedDrug prescribedDrug1 = new PrescribedDrug("12343", DateTime.Today, DateTime.Today.AddDays(2), 3, drug1);
            PrescribedDrug prescribedDrug2 = new PrescribedDrug("12342", DateTime.Today, DateTime.Today.AddDays(2), 3, drug2);
            List<PrescribedDrug> prescribedDrugs = new List<PrescribedDrug>();
            prescribedDrugs.Add(prescribedDrug1);
            prescribedDrugs.Add(prescribedDrug2);
            Therapy therapy = new Therapy(DateTime.Today, "1234", prescribedDrugs, patientChart1);
          
            therapyController.WriteTherapy(therapy);

            ReportOfExaminationController reportOfExaminationController = new ReportOfExaminationController(new Service.ServiceMedicalDocumentation.ReportOfExaminationService(new ReportOfExaminationRepository()));
            ReportOfExamination reportOfExamination1 = new ReportOfExamination("Pacijent dosao sa temperaturom", "COVID-19", "Temperatura", DateTime.Today, "563515", patientChart1);
            ReportOfExamination reportOfExamination2 = new ReportOfExamination("Pacijent se zali na bol u prstu", "Prelom prsta", "Bol u prstu", DateTime.Today, "275752", patientChart1);
            ReportOfExamination reportOfExamination3 = new ReportOfExamination("Pacijent se zali na bol u grlu", "Upala grla", "Bol u grlu", DateTime.Today, "563514", patientChart2);
            reportOfExaminationController.WriteReportOfExamination(reportOfExamination1);
            reportOfExaminationController.WriteReportOfExamination(reportOfExamination2);
            reportOfExaminationController.WriteReportOfExamination(reportOfExamination3);
            

            Console.WriteLine("**** IZVESTAJ ****");
            Console.WriteLine("Misljenje: ");
            string opinion = Console.ReadLine();
            Console.WriteLine("Dijagnoza: ");
            string diagnosis = Console.ReadLine();
            Console.WriteLine("Simptom: ");
            string symptom = Console.ReadLine();

            ReportOfExamination r = new ReportOfExamination(opinion, diagnosis, symptom, DateTime.Today, "5464", patientChart1);
            reportOfExaminationController.WriteReportOfExamination(r);

            //PISANJE IZVESTAJA
            Console.WriteLine("--- Napisani izvestaj: ---");
            Console.WriteLine("Misljenje: " + reportOfExaminationController.GetReportOfExaminationById("25275").Opinion);
            Console.WriteLine("Dijagnoza: " + reportOfExaminationController.GetReportOfExaminationById("25275").Diagnosis);
            Console.WriteLine("Simptom: " + reportOfExaminationController.GetReportOfExaminationById("25275").Symptom);
            Console.WriteLine("***********\n");
            ///

            //UPUT
            Console.WriteLine("Pisanje uputa: ");
            Console.WriteLine("Napisite obrazlozenje: ");
            string description = Console.ReadLine();
            Console.WriteLine("Izaberite lekara: ");
            Console.WriteLine("1. " + doctor1.Name + " " + doctor1.Surname);
            Console.WriteLine("2. " + doctor2.Name + " " + doctor2.Surname);
            Console.WriteLine("3. " + doctor3.Name + " " + doctor3.Surname);
            int i = int.Parse(Console.ReadLine());
            Doctor d = new Doctor();
            switch (i)
            {
                case 1:
                    d = doctor1;
                    break;
                case 2:
                    d = doctor2;
                    break;
                case 3:
                    d = doctor3;
                    break;
                default:
                    break;
            }

            ReferralLetter rl2 = new ReferralLetter(description, DateTime.Today, "65165", patientChart1, d);
            refLetCont.WriteReferralLetter(rl2);

            Console.WriteLine("Uput: ");
            Console.WriteLine("Obrazlozenje: " + refLetCont.GetReferralLetterById("65165").Description);
            Doctor doctorPrescription = doctorController.GetDoctorById(refLetCont.GetReferralLetterById("65165").Doctor.Pin);
            Console.WriteLine("Lekar: " + doctorPrescription.Name + " " + doctorPrescription.Surname);
            Console.WriteLine("*******************");
            ///////
            /// RECEPT
            Console.WriteLine("Recept: ");
            Console.WriteLine("Izaberite lek: ");
            Console.WriteLine("1. " + drug1.Name);
            Console.WriteLine("2. " + drug2.Name);
            Console.WriteLine("3. " + drug3.Name);
            int ii = int.Parse(Console.ReadLine());
            Drug dr = new Drug();
            switch (ii)
            {
                case 1:
                    dr = drug1;
                    break;
                case 2:
                    dr = drug2;
                    break;
                case 3:
                    dr = drug3;
                    break;
                default:
                    break;
            }
            Console.WriteLine("Opis: ");
            string description1 = Console.ReadLine();
            Prescription pres = new Prescription(description1, DateTime.Today.Date, "651651", dr, patientChart1);
            pr.WritePrescription(pres);
            Console.WriteLine("Recept: ");
            Console.WriteLine("Opis: " + pr.GetPrescriptionById("651651").Description);
            Console.WriteLine("**********\n");
            //RECEPT

            AppointmentController appointmentController = new AppointmentController(new AppointmentService(new OperationRepository(), new ExaminationRepository(), new DoctorRepository()));

            ////PREGLEDI ILI RASPORED
            Console.WriteLine("Pregledi: ");
            foreach (Appointment a in appointmentController.GetAllDoctorsAppointments(doctor1)) {
                Console.WriteLine("Vreme: " + a.Term.Start);
                Console.WriteLine("Pacijent: " + registeredPatientController.Get(a.RegisteredPatient.Pin).Name + " " + registeredPatientController.Get(a.RegisteredPatient.Pin).Surname);
            }
            /////

            //////KARTON

            Console.WriteLine("\nZDRAVSTVENI KARTON: \n");
            
            Console.WriteLine("Ime i prezime pacijenta: " + registeredPatientController.Get(patientChart1.RegisteredPatient.Pin).Name + " " + registeredPatientController.Get(patientChart1.RegisteredPatient.Pin).Surname +"\n");

            Console.WriteLine("--------Alergije--------");
            foreach (Allergy allergy in patientChart1.Allergies) {
                Console.WriteLine(allergy.Name);
            }

            Console.WriteLine("\n-----------Recepti-------------");
            List<Prescription> pre = pr.GetAllPrescriptionsByPatientChart(patientChart1);
            foreach (Prescription pp in pre)
            {
                Console.WriteLine("Opis: " + pp.Description);
                Drug drugg = drugRepository.Get(pp.Drug.Id);
                Console.WriteLine("Lek: " + drugg.Name);
                Console.WriteLine("***********");
            }
            Console.WriteLine("\n-----------Uputi-------------");
            List<ReferralLetter> referralLetters = refLetCont.GetAllReferralLettersByPatientChart(patientChart1);
            foreach (ReferralLetter referralLetter in referralLetters)
            {
                Console.WriteLine("Opis: " + referralLetter.Description);
                Doctor doctor = doctorController.GetDoctorById(referralLetter.Doctor.Pin);
                Console.WriteLine("Lekar: " + doctor.Name + " " + doctor.Surname);
                Console.WriteLine("***********");

            }
            Console.WriteLine("\n-----------Terapije-------------");
            foreach (Therapy t in therapyController.GetAllTherapiesByPatientChart(patientChart1))
            {
                foreach (PrescribedDrug pd in t.PrescribedDrugs)
                {
                    Drug pdrug = drugRepository.Get(pd.Drug.Id);
                    Console.WriteLine("Naziv leka: " + pdrug.Name); //iz repo uzeti Drug
                    Console.WriteLine("Dnevni unso: " + pd.DailyDose);
                }
                Console.WriteLine("***********");
            }

            Console.WriteLine("\n-------------Prethdoni izvestaji-------------");
            foreach (ReportOfExamination repOfExam in reportOfExaminationController.GetAllReportOfExaminationByPatientChart(patientChart1))
            {
                Console.WriteLine("Misljenje: " + repOfExam.Opinion);
                Console.WriteLine("Dijagnoza: " + repOfExam.Diagnosis);
                Console.WriteLine("Simptom: " + repOfExam.Symptom);
                Console.WriteLine("***********");
            }*/

            ////////////////KARTON

            bool Running = true;
            while (Running)
            {
                Console.WriteLine(" \n****** LEKAR ****** ");
                Console.WriteLine("1. Pisanje izvestaja o pregledu");
                Console.WriteLine("2. Izdavanje uputa");
                Console.WriteLine("3. Izdavanje recepta");
                Console.WriteLine("4. Pisanje clanka");
                Console.WriteLine("5. Pregled (karton pacijenta)");
                Console.WriteLine("6. Raspored za danas");
                Console.WriteLine("7. Odgovaranje na pitanje");
                Console.WriteLine("8. Odobravanje leka");
                Console.WriteLine("9. Zakazivanje pregleda");
                int input = 9;
                while (!Int32.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Unos mora biti ceo broj!");
                }
                switch (input)
                {
                    case 1:
                        WriteReportOfExam();
                        break;
                    case 2:
                        WriteReferralLetter();
                        break;
                    case 3:
                        WritePrescription();
                        break;
                    case 4:
                        WriteArticle();
                        break;
                    case 5:
                        ViewExam();
                        break;
                    case 6:
                        ViewAppointments();
                        break;
                    case 7:
                        AnswerQuestion();
                        break;
                    case 8:
                        Approve();
                        break;
                    case 9:
                        zakazi();
                        break;
                    case 0:
                        {
                            Running = false;
                        }
                        break;
                    default: break;
                }
            }


            /*

            Console.WriteLine("1 --------- Pisanje izvestaja o pregledu");
            Console.WriteLine("2 --------- Izdavanje uputa");
            Console.WriteLine("3 --------- Izdavanje recepta");
            Console.WriteLine("4 --------- Pisanje clanka");
            Console.WriteLine("5 --------- Pregled (karton pacijenta)");
            Console.WriteLine("6 --------- Raspored za danas");
            Console.WriteLine("7 --------- Odgovaranje na pitanje");
            Console.WriteLine("8 --------- Odobravanje leka");
            Console.WriteLine("9 --------- Zakazivanje pregleda");
            int iii = int.Parse(Console.ReadLine());
            switch (iii)
            {
                case 1:
                    WriteReportOfExam();
                    break;
                case 2:
                    WriteReferralLetter();
                    break;
                case 3:
                    WritePrescription();
                    break;
                case 4:
                    WriteArticle();
                    break;
                case 5:
                    ViewExam();
                    break;
                case 6:
                    ViewAppointments();
                    break;
                case 7:
                    AnswerQuestion();
                    break;
                case 8:
                    Approve();
                    break;
                case 9:
                    zakazi();
                    break;
                default:
                    break;
            }
            */
        }


        public static void Approve()
        {
            ApprovalController approvalController = new ApprovalController(new ApprovalServices(new ApprovalRepository(new DrugRepository()), new DrugServices(new DrugRepository())));
            DrugController drugController = new DrugController(new DrugServices(new DrugRepository()));

            List<DrugApproval> drugApprovals = approvalController.GetPending();
            if (drugApprovals.Count != 0)
            {

                Console.WriteLine("\n*** ODOBRAVANJE LEKA **** ");
                Console.WriteLine("Opis: ");
                Console.WriteLine(drugApprovals[0].RequestBody);
                Drug drug = drugController.Get(drugApprovals[0].DrugtoBeApproved.Id);
                Console.WriteLine("Lek: " + drug.Name);
                Console.WriteLine("Komentar: ");
                string comment = Console.ReadLine();
                Console.WriteLine("1. odobravam");
                Console.WriteLine("2. ne odobravam");
                int i = int.Parse(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        approvalController.Accept(drugApprovals[0].Id, comment);
                        break;
                    case 2:
                        approvalController.Reject(drugApprovals[0].Id, comment);
                        break;
                    default:
                        break;
                }
            }
        }

        public static void AnswerQuestion() {
            DoctorController doctorController = new DoctorController(new DoctorService(new DoctorRepository()));
            QuestionController questionController = new QuestionController(new QuestionService(new QuestionsRepository()));

            List<Doctor> doctors = doctorController.GetAllDoctors();

            List<Question> questions = questionController.GetAllQuestions();

            if (questions.Count != 0)
            {
                Console.WriteLine("PITANJE: ");
                Console.WriteLine(questions[0].Text);

                Console.WriteLine("\nOdgovor: ");
                string answer = Console.ReadLine();

                Content answerContent = new Content("6546135", answer, DateTime.Now);
                questionController.AnswerQuestion(questions[0], answerContent, doctors[0]);
            }
        }

        public static void WriteReportOfExam() {

            ReportOfExaminationController reportOfExaminationController = new ReportOfExaminationController(new ReportOfExaminationService(new ReportOfExaminationRepository()));
            PatientChartController patientChartController = new PatientChartController(new PatientChartService(new PatientChartRepository()));
            List<PatientChart> patientCharts = patientChartController.GetAllPatientCharts();
            PatientChart patientChart1 = patientCharts[0];

            Console.WriteLine("\n**** IZVESTAJ ****\n");
            Console.WriteLine("Misljenje: ");
            string opinion = Console.ReadLine();
            Console.WriteLine("\nDijagnoza: ");
            string diagnosis = Console.ReadLine();
            Console.WriteLine("\nSimptom: ");
            string symptom = Console.ReadLine();

            RandomStringGenerator randomId = new RandomStringGenerator(8);
            while (reportOfExaminationController.GetReportOfExaminationById(randomId.RandomString) != null)
            {
                randomId = new RandomStringGenerator(8);
            }


            ReportOfExamination r = new ReportOfExamination(opinion, diagnosis, symptom, DateTime.Today, randomId.RandomString, patientChart1);
            reportOfExaminationController.WriteReportOfExamination(r);

            //PISANJE IZVESTAJA
            Console.WriteLine("\n--- Napisani izvestaj: ---\n");
            Console.WriteLine("Misljenje: " + reportOfExaminationController.GetReportOfExaminationById(randomId.RandomString).Opinion);
            Console.WriteLine("Dijagnoza: " + reportOfExaminationController.GetReportOfExaminationById(randomId.RandomString).Diagnosis);
            Console.WriteLine("Simptom: " + reportOfExaminationController.GetReportOfExaminationById(randomId.RandomString).Symptom);
            Console.WriteLine("Datum: " + reportOfExaminationController.GetReportOfExaminationById(randomId.RandomString).Date.ToShortDateString());
            Console.WriteLine("***********\n");
        }

        public static void WriteReferralLetter() {

            DoctorController doctorController = new DoctorController(new DoctorService(new DoctorRepository()));
            ReferralLetterController referralLetterController = new ReferralLetterController(new ReferralLetterService(new ReferralLetterRepository()));
            PatientChartController patientChartController = new PatientChartController(new PatientChartService(new PatientChartRepository()));

            List<Doctor> doctors = doctorController.GetAllDoctors();
            List<PatientChart> patientCharts = patientChartController.GetAllPatientCharts();

            if (doctors.Count != 0)
            {

                Console.WriteLine("\n***** UPUT *****\n ");
                Console.WriteLine("Napisite obrazlozenje: ");
                string description = Console.ReadLine();
                Console.WriteLine("\nIzaberite lekara: ");
                Console.WriteLine("1. " + doctors[0].Name + " " + doctors[0].Surname);
                Console.WriteLine("2. " + doctors[1].Name + " " + doctors[1].Surname);
                Console.WriteLine("3. " + doctors[2].Name + " " + doctors[2].Surname);
                int i = int.Parse(Console.ReadLine());
                Doctor d = new Doctor();
                switch (i)
                {
                    case 1:
                        d = doctors[0];
                        break;
                    case 2:
                        d = doctors[1];
                        break;
                    case 3:
                        d = doctors[2];
                        break;
                    default:
                        break;
                }


                RandomStringGenerator randomId = new RandomStringGenerator(8);
                while (referralLetterController.GetReferralLetterById(randomId.RandomString) != null)
                {
                    randomId = new RandomStringGenerator(8);
                }

                ReferralLetter rl2 = new ReferralLetter(description, DateTime.Today, randomId.RandomString, patientCharts[0], d);
                referralLetterController.WriteReferralLetter(rl2);

                Console.WriteLine("--- Napisani uput: ---");
                Console.WriteLine("Obrazlozenje: " + referralLetterController.GetReferralLetterById(randomId.RandomString).Description);
                Doctor doctorPrescription = doctorController.GetDoctorById(referralLetterController.GetReferralLetterById(randomId.RandomString).Doctor.Pin);
                Console.WriteLine("Lekar: " + doctorPrescription.Name + " " + doctorPrescription.Surname);
                Console.WriteLine("Datum: " + referralLetterController.GetReferralLetterById(randomId.RandomString).Date.ToShortDateString());
                Console.WriteLine("*******************\n");

            }
        }

        public static void WritePrescription() {

            PrescriptionController prescriptionController = new PrescriptionController(new PrescriptionService(new PrescriptionRepository()));
            PatientChartController patientChartController = new PatientChartController(new PatientChartService(new PatientChartRepository()));
            DrugController drugController = new DrugController(new DrugServices(new DrugRepository()));
            List<PatientChart> patientCharts = patientChartController.GetAllPatientCharts();
            PatientChart patientChart1 = patientCharts[0];
            List<Drug> drugs = drugController.GetAll();

            if (drugs.Count != 0)
            {

                Console.WriteLine("\n**** RECEPT ****\n");
                Console.WriteLine("Izaberite lek: ");
                Console.WriteLine("1. " + drugs[0].Name);
                Console.WriteLine("2. " + drugs[1].Name);
                Console.WriteLine("3. " + drugs[2].Name);
                int ii = int.Parse(Console.ReadLine());
                Drug dr = new Drug();
                switch (ii)
                {
                    case 1:
                        dr = drugs[0];
                        break;
                    case 2:
                        dr = drugs[1];
                        break;
                    case 3:
                        dr = drugs[2];
                        break;
                    default:
                        break;
                }
                Console.WriteLine("\nOpis: ");
                string description1 = Console.ReadLine();

                RandomStringGenerator randomId = new RandomStringGenerator(8);
                while (prescriptionController.GetPrescriptionById(randomId.RandomString) != null)
                {
                    randomId = new RandomStringGenerator(8);
                }


                Prescription pres = new Prescription(description1, DateTime.Today.Date, randomId.RandomString, dr, patientChart1);
                prescriptionController.WritePrescription(pres);
                Console.WriteLine("\n--- Napisani recept --- \n");
                Console.WriteLine("Lek: " + drugController.Get(dr.Id).Name);
                Console.WriteLine("Opis: " + prescriptionController.GetPrescriptionById(randomId.RandomString).Description);
                Console.WriteLine("Datum: " + prescriptionController.GetPrescriptionById(randomId.RandomString).Date.ToShortDateString());

                Console.WriteLine("*************\n");

            }
        }

        public static void WriteArticle() {

            DoctorController doctorController = new DoctorController(new Service.ServiceDoctor.DoctorService(new DoctorRepository()));
            BlogArticleController blogArticleController = new BlogArticleController(new BlogArticleService(new BlogArticlesRepository()));

            List<Doctor> doctors = doctorController.GetAllDoctors();

            RandomStringGenerator randomId = new RandomStringGenerator(8);
            while (blogArticleController.GetArticleById(randomId.RandomString) != null)
            {
                randomId = new RandomStringGenerator(8);
            }

            Console.WriteLine("\n*** PISANJE CLANKA *** ");
            Console.WriteLine("\nNaslov: ");
            string title = Console.ReadLine();
            Console.WriteLine("\nSadrzaj: ");
            string content = Console.ReadLine();


            BlogArticle blogArticle = new BlogArticle(title, doctors[0], randomId.RandomString, content, DateTime.Now);
            blogArticleController.NewArticle(blogArticle);

            Console.WriteLine("\n --- Napisani clanak ---");
            Console.WriteLine("\nNaslov: ");
            Console.WriteLine(blogArticleController.GetArticleById(randomId.RandomString).Title);
            Console.WriteLine("Sadrzaj: ");
            Console.WriteLine(blogArticleController.GetArticleById(randomId.RandomString).Text);
            Console.WriteLine("Datum: " + blogArticleController.GetArticleById(randomId.RandomString).DateOfCreation.ToShortDateString());

        }

        public static void ViewExam() {

            DoctorController doctorController = new DoctorController(new DoctorService(new DoctorRepository()));
            RegisteredPatientController registeredPatientController = new RegisteredPatientController(new RegisteredPatientService(new RegisteredPatientRepository(), new RegisteredUserRepository(), new PatientChartRepository()));
            ReferralLetterController referralLetterController = new ReferralLetterController(new ReferralLetterService(new ReferralLetterRepository()));
            PatientChartController patientChartController = new PatientChartController(new PatientChartService(new PatientChartRepository()));
            PrescriptionController prescriptionController = new PrescriptionController(new PrescriptionService(new PrescriptionRepository()));
            ReportOfExaminationController reportOfExaminationController = new ReportOfExaminationController(new ReportOfExaminationService(new ReportOfExaminationRepository()));
            TherapyController therapyController = new TherapyController(new TherapyService(new TherapyRepository()));
            DrugController drugController = new DrugController(new DrugServices(new DrugRepository()));

            List<PatientChart> patientCharts = patientChartController.GetAllPatientCharts();
            PatientChart patientChart1 = patientCharts[0];

            Console.WriteLine("\n**** ZDRAVSTVENI KARTON ***** \n");

            Console.WriteLine("Ime i prezime pacijenta: " + registeredPatientController.Get(patientChart1.RegisteredPatient.Pin).Name + " " + registeredPatientController.Get(patientChart1.RegisteredPatient.Pin).Surname + "\n");

            Console.WriteLine("--------Alergije--------");
            foreach (Allergy allergy in patientChart1.Allergies)
            {
                Console.WriteLine(allergy.Name);
            }

            Console.WriteLine("\n-----------Recepti-------------");
            List<Prescription> pre = prescriptionController.GetAllPrescriptionsByPatientChart(patientChart1);
            foreach (Prescription pp in pre)
            {
                Console.WriteLine("Opis: " + pp.Description);
                Drug drugg = drugController.Get(pp.Drug.Id);
                Console.WriteLine("Lek: " + drugg.Name);
                Console.WriteLine("Datum: " + pp.Date.ToShortDateString());
                Console.WriteLine("***********");
            }
            Console.WriteLine("\n-----------Uputi-------------");
            List<ReferralLetter> referralLetters = referralLetterController.GetAllReferralLettersByPatientChart(patientChart1);
            foreach (ReferralLetter referralLetter in referralLetters)
            {
                Console.WriteLine("Opis: " + referralLetter.Description);
                Doctor doctor = doctorController.GetDoctorById(referralLetter.Doctor.Pin);
                Console.WriteLine("Lekar: " + doctor.Name + " " + doctor.Surname);
                Console.WriteLine("Datum: " + referralLetter.Date.ToShortDateString());
                Console.WriteLine("***********");

            }
            Console.WriteLine("\n-----------Terapije-------------");
            foreach (Therapy t in therapyController.GetAllTherapiesByPatientChart(patientChart1))
            {
                foreach (PrescribedDrug pd in t.PrescribedDrugs)
                {
                    Drug pdrug = drugController.Get(pd.Drug.Id);
                    Console.WriteLine("Naziv leka: " + pdrug.Name);
                    Console.WriteLine("Dnevni unos: " + pd.DailyDose);
                }
                Console.WriteLine("***********");
            }

            Console.WriteLine("\n-------------Istorija bolesti-------------");
            foreach (ReportOfExamination repOfExam in reportOfExaminationController.GetAllReportOfExaminationByPatientChart(patientChart1))
            {
                Console.WriteLine("Dijagnoza: " + repOfExam.Diagnosis);
                Console.WriteLine("Simptom: " + repOfExam.Symptom);
                Console.WriteLine("Datum: " + repOfExam.Date.ToShortDateString());
                Console.WriteLine("***********");
            }
            
        }

        public static void ViewAppointments() {

            AppointmentController appointmentController = new AppointmentController(new AppointmentService(new OperationRepository(), new ExaminationRepository(), new DoctorRepository()));
            RegisteredPatientController registeredPatientController = new RegisteredPatientController(new RegisteredPatientService(new RegisteredPatientRepository(), new RegisteredUserRepository(), new PatientChartRepository()));
            DoctorController doctorController = new DoctorController(new DoctorService(new DoctorRepository()));

            List<RegisteredPatient> patients = registeredPatientController.GetAll();
            List<Doctor> doctors = doctorController.GetAllDoctors();

            /*Room examRoom1 = new Room("roomId1", "202", false, RoomType.EXAMROOM);
            Room examRoom2 = new Room("roomId2", "203", false, RoomType.EXAMROOM);
            Room examRoom3 = new Room("roomId3", "204", false, RoomType.EXAMROOM);

            Examination exam1 = new Examination(examRoom1, false, "864315", AppointmentType.EXAMINATION, patients[0], new Term(DateTime.Today.AddHours(7).AddMinutes(0), DateTime.Today.AddHours(7).AddMinutes(30)), doctors[0], DateTime.Today.Date);
            Examination exam2 = new Examination(examRoom1, false, "684651", AppointmentType.EXAMINATION, patients[1], new Term(DateTime.Today.AddHours(7).AddMinutes(30), DateTime.Today.AddHours(8).AddMinutes(0)), doctors[0], DateTime.Today.Date);
            Examination exam3 = new Examination(examRoom1, false, "541545", AppointmentType.EXAMINATION, patients[2], new Term(DateTime.Today.AddHours(8).AddMinutes(0), DateTime.Today.AddHours(8).AddMinutes(30)), doctors[0], DateTime.Today.Date);
            Examination exam4 = new Examination(examRoom2, false, "463155", AppointmentType.EXAMINATION, patients[1], new Term(DateTime.Today.AddHours(8).AddMinutes(0), DateTime.Today.AddHours(8).AddMinutes(30)), doctors[1], DateTime.Today.Date);
            Examination exam5 = new Examination(examRoom3, false, "282652", AppointmentType.EXAMINATION, patients[2], new Term(DateTime.Today.AddHours(15).AddMinutes(30), DateTime.Today.AddHours(16).AddMinutes(0)), doctors[2], DateTime.Today.Date);


            ExaminationController examinationController = new ExaminationController(new ExaminationService(new ExaminationRepository(), new OperationRepository(), new DoctorRepository()));
            examinationController.ScheduleExam(exam1);
            examinationController.ScheduleExam(exam2);
            examinationController.ScheduleExam(exam3);
            examinationController.ScheduleExam(exam4);
            examinationController.ScheduleExam(exam5);*/

            if (appointmentController.GetAllDoctorsAppointmentsToday(doctors[0]).Count != 0)
            {
                Console.WriteLine("\n *** DANASNJI TERMINI (RASPORED) *** \n");
                foreach (Appointment a in appointmentController.GetAllDoctorsAppointmentsToday(doctors[0]))
                {
                    Console.WriteLine("Vreme: " + a.Term.Start);
                    Console.WriteLine("Pacijent: " + registeredPatientController.Get(a.RegisteredPatient.Pin).Name + " " + registeredPatientController.Get(a.RegisteredPatient.Pin).Surname);
                    Console.WriteLine("******************");
                }
            }
            else {
                Console.WriteLine("Nemate zakazane termine danas");
            }

        }

        public static void zakazi()
        {
           
            DoctorController doctorController = new DoctorController(new Service.ServiceDoctor.DoctorService(new DoctorRepository()));
            AppointmentController appointmentController = new AppointmentController(new AppointmentService(new OperationRepository(), new ExaminationRepository(), new DoctorRepository()));
            RegisteredPatientController registeredPatientController = new RegisteredPatientController(new RegisteredPatientService(new RegisteredPatientRepository(), new RegisteredUserRepository(), new PatientChartRepository()));
            ExaminationController examinationController = new ExaminationController(new ExaminationService(new ExaminationRepository(),new OperationRepository(), new DoctorRepository()));

            List<RegisteredPatient> patients = registeredPatientController.GetAll();

            List<Doctor> doctors = doctorController.GetAllDoctors();
            Console.WriteLine(doctors.Count);
            Dictionary<int, string> doctorsDict = new Dictionary<int, string>();

            Console.WriteLine("Odaberite lekara: ");
            for (int i = 0; i < doctors.Count; i++)
            {
                doctorsDict.Add(i, doctors[i].Pin);
                Console.WriteLine(i + " - " + doctors[i].Name + " " + doctors[i].Surname);
            }
            int input = -1;
            bool Running = true;
            while (Running)
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                    if (input >= 0 && input < doctors.Count)
                        Running = false;
                    else
                        Console.WriteLine("Unesite podesan broj");
                }
                catch
                {
                    Console.WriteLine("Nije dobar unos! Ponovite izbor!");
                }
            }
            Doctor doctor = doctorController.GetDoctorById(doctorsDict[input]);
            Console.WriteLine("Odaberite datum za pregled!");
            DateTime examDate = chooseDate();
            List<Term> freeTermsForDate = appointmentController.GetAllDoctorsFreeTermsForDate(doctor, examDate);
            if (freeTermsForDate == null)
            {
                Console.WriteLine("Za odabrani datum nema slobodnih termina");
            }
            else
            {
                Dictionary<int, Term> termsDict = new Dictionary<int, Term>();

                for (int counter = 0; counter < freeTermsForDate.Count; counter++)
                {
                    Console.WriteLine(counter + " - " + freeTermsForDate[counter].Start);
                    Console.WriteLine("----");
                    termsDict.Add(counter, freeTermsForDate[counter]);
                }

                input = -1;
                Running = true;
                while (Running)
                {
                    try
                    {
                        input = int.Parse(Console.ReadLine());
                        if (input >= 0 && input < freeTermsForDate.Count)
                            Running = false;
                        else
                            Console.WriteLine("Unesite podesan broj");
                    }
                    catch
                    {
                        Console.WriteLine("Nije dobar unos! Ponovite izbor!");
                    }
                }

                Term examTerm = termsDict[input];

                RandomStringGenerator randomId = new RandomStringGenerator(9);
                while (examinationController.GetExamById(randomId.RandomString) != null)
                {
                    randomId = new RandomStringGenerator(9);
                }

                Room examRoom = examRoomController.GetExamRoomById(doctor.DefaultExamRoom.Id);

                Examination examination = new Examination(examRoom, false, randomId.RandomString, AppointmentType.EXAMINATION, patients[0], examTerm, doctor, examDate);
                examinationController.ScheduleExam(examination);

            }
        }

        private static DateTime chooseDate()
        {
            int year = chooseYear();
            int month = chooseMonth();
            int day = chooseDay(DateTime.DaysInMonth(year, month));
            return new DateTime(year, month, day);
        }

        private static int chooseDay(int numberOfDaysInMonth)
        {
            Console.WriteLine("Unesite dan: ");
            while (true)
            {
                try
                {
                    int day = int.Parse(Console.ReadLine());
                    if (day <= numberOfDaysInMonth && day > 0)
                        return day;
                    else
                        Console.WriteLine("Nije dobar dan odabran! Ponovite unos!");
                }
                catch
                {
                    Console.WriteLine("Dan nije unet u dobrom formatu! Ponovite unos!");
                }
            }
        }
        private static int chooseYear()
        {
            Console.WriteLine("Unesite godinu: ");
            while (true)
            {
                try
                {
                    int year = int.Parse(Console.ReadLine());
                    if (year <= 2020)
                        return year;
                    else
                        Console.WriteLine("Nije odabrana dobra godina! Ponovite unos!");
                }
                catch
                {
                    Console.WriteLine("Nije uspesno uneta godina! Ponovite unos!");
                }
            }
        }
        private static int chooseMonth()
        {
            Dictionary<string, int> months = new Dictionary<string, int>();

            months.Add("Januar", 1);
            months.Add("Februar", 2);
            months.Add("Mart", 3);
            months.Add("April", 4);
            months.Add("Maj", 5);
            months.Add("Jun", 6);
            months.Add("Jul", 7);
            months.Add("Avgust", 8);
            months.Add("Septembar", 9);
            months.Add("Oktobar", 10);
            months.Add("Novembar", 11);
            months.Add("Decembar", 12);
            Console.WriteLine("Odaberite mesec: ");
            foreach (KeyValuePair<string, int> keyValuePair in months)
            {
                Console.WriteLine(keyValuePair.Key + " - " + keyValuePair.Value);
            }

            while (true)
            {
                try
                {
                    int month = int.Parse(Console.ReadLine());

                    if (!months.Values.Contains(month))
                        Console.WriteLine("Niste odabrali dobar mesec! Ponovite izbor!");
                    else
                        return month;
                }
                catch
                {
                    Console.WriteLine("Nije dobar unos! Ponovite izbor!");
                }

            }
        }
        public static void PrintExamRooms()
        {
            foreach (Room r in examRoomController.GetAll())
            {
                Console.WriteLine(r);
            }
        }

        public static void PrintOpRooms()
        {
            foreach (Room r in operationRoomController.GetAll())
            {
                Console.WriteLine(r);
            }
        }

        public static void PrintRecRooms()
        {
            foreach (Room r in recoveryRoomController.GetAll())
            {
                Console.WriteLine(r);
            }
        }
        public static void PrintRooms()
        {
            Console.WriteLine("ID IME\tTIP");
            PrintRecRooms();
            PrintOpRooms();
            PrintExamRooms();
            Console.WriteLine(storageController.Get());
        }

        public static void PrintItems()
        {
            Console.WriteLine("ID KOL.\tIME");
            foreach (Item item in itemController.GetAll())
            {
                Console.WriteLine(item);
            }
        }

        public static void PrintDrugs()
        {
            Console.WriteLine("ID KOL.\tIME");
            foreach (Drug drug in drugController.GetAll())
            {
                Console.WriteLine(drug);
            }
        }

        public static void DeanReports() 
        {
            int Option = 0;
            while(true)
            {
                DateTime defaultStart = DateTime.Now;
                DateTime defaultEnd = DateTime.Now.AddDays(10);
                Console.WriteLine("====Upravnik izvestaji====");
                Console.WriteLine("\t1. Odaberite sobu");
                Console.WriteLine("\t0. Nazad");
                Console.WriteLine("Odaberite opciju:");
                string opt = Console.ReadLine();
                if(!Int32.TryParse(opt, out Option))
                {
                    Console.WriteLine("Nevalidan unos!");
                    continue;
                }
                switch(Option)
                {
                    case 1:
                        {
                            PrintRooms();
                            Console.WriteLine("Unesite ID sobe:");
                            string id = Console.ReadLine();
                            Console.WriteLine("Default izvestaj od " + defaultStart.ToString("dd/MM/yyyy") + " do" + defaultEnd.ToString("dd/MM/yyyy"));
                            Room room;
                            if(id.StartsWith("er"))
                            {
                                room = examRoomController.Get(id);
                            }
                            else if(id.StartsWith("or"))
                            {
                                room = operationRoomController.Get(id);
                            }
                            else if(id.StartsWith("rr"))
                            {
                                room = recoveryRoomController.Get(id);
                            }
                            else
                            {
                                room = storageController.Get();
                            }
                            ScheduleReport report = deanReportController.Get(defaultStart, defaultEnd, room);
                            Console.WriteLine(report.Content);
                            Console.WriteLine("Downloading pdf...");
                            deanReportController.DownloadReport(report);

                        }break;

                    case 0:
                        {
                            return;
                        }
                }
            }
        }
        public static void DeanStaff()
        {
            int Option = 0;
            while (true)
            {
                Console.WriteLine("====Upravnik zaposleni====");
                Console.WriteLine("\t1. Izlistaj zaposlene");
                Console.WriteLine("\t2. Posalji na odmor");
                Console.WriteLine("\t3. Vrati na posao");
                Console.WriteLine("\t0. Nazad");
                Console.WriteLine("Odaberite opciju:");
                Console.WriteLine("Zaposleni lekari");
                string opt = Console.ReadLine();
                if(!Int32.TryParse(opt, out Option))
                {
                    Console.WriteLine("Nevalidan unos!");
                    continue;
                }
                switch(Option)
                {
                    case 1:
                        {
                            Console.WriteLine("ID IME\tSTATUS");
                            foreach (Doctor doctor in staffController.GetAllDoctors())
                            {
                                Console.WriteLine(doctor);
                            }
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Unesite ID:");
                            string id = Console.ReadLine();
                            staffController.MoveToVacation(id);
                        }break;

                    case 3:
                        {
                            Console.WriteLine("Unesite ID:");
                            string id = Console.ReadLine();
                            staffController.MoveToWorking(id);
                        } break;
                    case 0:
                        {
                            return;
                        }
                }
            }
        }
        public static void DeanInventory()
        {
            int Option = 0;
            while(true)
            {
                Console.WriteLine("====Upravnik inventar====");
                Console.WriteLine("\t1. Izlistaj sve predmete");
                Console.WriteLine("\t2. Izlistaj sve lekove");
                Console.WriteLine("\t3. Predmeti i lekovi u sobi");
                Console.WriteLine("\t4. Premesti predmet");
                Console.WriteLine("\t0. Nazad");
                Console.WriteLine("Odaberite opciju:");
                string opt = Console.ReadLine();
                if(!Int32.TryParse(opt, out Option))
                {
                    Console.WriteLine("Nevalidna opcija!");
                    continue;
                }
                switch(Option)
                {
                    case 1:
                        {
                            PrintItems();
                        } break;
                    case 2:
                        {
                            PrintDrugs();
                        }break;

                    case 3:
                        {
                            PrintRooms();
                            Console.WriteLine("Unesite id sobe:");
                            string id = Console.ReadLine();
                            List<Item> items;
                            if(id.StartsWith("er"))
                            {
                                items = examRoomController.GetItems(id);
                            }
                            else if (id.StartsWith("or"))
                            {
                                items = operationRoomController.GetItems(id);
                            }
                            else if (id.StartsWith("rr"))
                            {
                                items = recoveryRoomController.GetItems(id);
                            }
                            else
                            {
                                items = storageController.GetItems();
                            }
                            foreach(Item item in items)
                            {
                                Console.WriteLine(item);
                            }
                        }break;

                    case 4:
                        {
                            Room roomFrom, roomTo;
                            Item item;
                            PrintRooms();
                            Console.WriteLine("Id sobe iz koje prenosite");
                            string idFrom = Console.ReadLine();
                            Console.WriteLine("Id sobe u koju prenosite");
                            string idTo = Console.ReadLine();
                            int count;
                            Console.WriteLine("Id predmeta");
                            string itemId = Console.ReadLine();
                            item = itemController.Get(itemId);
                            Console.WriteLine("Kolicina");
                            string ct = Console.ReadLine();
                            Int32.TryParse(ct, out count);
                            item.Count = count;
                            
                            if (idFrom.StartsWith("er"))
                            {
                                roomFrom = examRoomController.Get(idFrom);
                            }
                            else if (idFrom.StartsWith("or"))
                            {
                                roomFrom = operationRoomController.Get(idFrom);
                            }
                            else if (idFrom.StartsWith("rr"))
                            {
                                roomFrom = recoveryRoomController.Get(idFrom);
                            }
                            else
                            {
                                roomFrom = storageController.Get();
                            }


                            if (idTo.StartsWith("er"))
                            {
                                roomTo = examRoomController.Get(idTo);
                            }
                            else if (idTo.StartsWith("or"))
                            {
                                roomTo = operationRoomController.Get(idTo);
                            }
                            else if (idTo.StartsWith("rr"))
                            {
                                roomTo = recoveryRoomController.Get(idTo);
                            }
                            else
                            {
                                roomTo = storageController.Get();
                            }

                            itemController.Move(roomFrom, roomTo, item);

                        } break;

                    case 0: { return; }
                }
            }
        }
        public static void DeanRooms()
        {
            int Option = 0;
            while (true)
            {
                Console.WriteLine("====Upravnik prostorije====");
                Console.WriteLine("\t1. Izlistaj sve");
                Console.WriteLine("\t0. Nazad");
                Console.WriteLine("Odaberite opciju:");

                string opt = Console.ReadLine();
                if(!Int32.TryParse(opt, out Option))
                {
                    Console.WriteLine("Nevalidna opcija!");
                    continue;
                }
                switch(Option)
                {
                    case 1:
                        {
                            PrintRooms();
                        } break;

                    case 0: { return; }
                }
            }
        }
        static void DeanOptions()
        {
            int Option = 0;
            while(true)
            {
                Console.WriteLine("====Upravnik meni====");
                Console.WriteLine("\t1. Izveštaji");
                Console.WriteLine("\t2. Zaposleni");
                Console.WriteLine("\t3. Inventar");
                Console.WriteLine("\t4. Prostorije");
                Console.WriteLine("\t5. Ucitaj test podatke");
                Console.WriteLine("\t0. Glavni meni");

                Console.WriteLine("Odaberite opciju:");
                string opt = Console.ReadLine();
                if(!Int32.TryParse(opt, out Option))
                {
                    Console.WriteLine("Unos mora biti broj!");
                    continue;
                }
                switch(Option)
                {
                    case 1:
                        {
                            DeanReports();
                        } break;
                    case 2:
                        {
                            DeanStaff();
                        } break;
                    case 3:
                        {
                            DeanInventory();
                        } break;
                    case 4:
                        {
                            DeanRooms();
                        } break;

                    case 5:
                        {
                            IDSequencer ItemSequencer = new IDSequencer("it");
                            IDSequencer DrugSequencer = new IDSequencer("drug");
                            IDSequencer ExamRoomSequencer = new IDSequencer("er");
                            IDSequencer OperatingRoomSequencer = new IDSequencer("or");
                            IDSequencer RecoveryRoomSequencer = new IDSequencer("rr");
                            IDSequencer ApprovalSequencer = new IDSequencer("app");

                            IDSequencer DoctorSequencer = new IDSequencer("dr");



                            Item i1 = new Item(ItemSequencer.Next(), 1, "One ring");
                            Item i2 = new Item(ItemSequencer.Next(), 3, "Elven rings");
                            Item i3 = new Item(ItemSequencer.Next(), 7, "Dwarf rings");
                            Item i4 = new Item(ItemSequencer.Next(), 9, "Human rings");
                            itemController.Add(i1);
                            itemController.Add(i2);
                            itemController.Add(i3);
                            itemController.Add(i4);

                            Drug d1 = new Drug("Mordor & Co.", DrugSequencer.Next(), 42, "Halfling's leaf");
                            Drug d2 = new Drug("Elves Inc.", DrugSequencer.Next(), 4, "Miruvórë");
                            Drug d3 = new Drug("Elves Inc.", DrugSequencer.Next(), 3, "Lembas bread");
                            Drug d4 = new Drug("Hemofarm AD Vrsac", DrugSequencer.Next(), 10, "Febricet 500mg");
                            drugController.Add(d1);
                            drugController.Add(d2);
                            drugController.Add(d3);

                            Room ex1 = new Room(ExamRoomSequencer.Next(), "Rivendell", true, RoomType.EXAMROOM);
                            Room re1 = new Room(RecoveryRoomSequencer.Next(), "Shire", true, RoomType.RECOVERYROOM);
                            Room op1 = new Room(OperatingRoomSequencer.Next(), "Swamps", true, RoomType.OPERATINGROOM);
                            Room storage = storageController.Get();
                            examRoomController.AddRoom(ex1);
                            recoveryRoomController.AddRoom(re1);
                            operationRoomController.AddRoom(op1);
                            examRoomController.AddItem("er0", i2);
                            storageController.AddItem(d1);
                            storageController.AddItem(i1);
                            storageController.AddItem(i3);
                            storageController.AddItem(i4);
                            storageController.AddItem(d2);
                            storageController.AddItem(d3);

                            DrugApproval da1 = new DrugApproval(d4.Name, "Želim febricet, pls", ApprovalSequencer.Next(), d4);
                            LoadPatientsDoctorsMedicalDocumentation();


                        }
                        break;

                    case 0:
                        {
                            return;
                        }
                }
            }
        }
        //EXAMS I FREE TERMS
        /*static void ShowFreeTerms() {
            City city = new City("Kekenda", 21000);
            State state = new State("Vodzvodina");
            Address address = new Address("Legijina", 1);
            Location location = new Location(state, city, address);

            Account account = new Account("pera", "pera");
            Account acc2 = new Account("kris", "kris");
            RegisteredUser registeredUser = new RegisteredUser(account, "Pera", "Peric", "123141", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Perica", city, location);


            Room examRoom = new Room("roomId1", "202", false, RoomType.EXAMROOM);
            Room operRoom = new Room("roomId2", "202", false, RoomType.OPERATINGROOM);

            Doctor doc = new Doctor("orl", examRoom, operRoom, acc2, "Kris", "Peric", "123141", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Perica", city, location);

            RegisteredPatient registeredPatient = new RegisteredPatient(doc, registeredUser);


            Examination exam1 = new Examination(examRoom, false, "864315", AppointmentType.EXAMINATION, registeredPatient, new Term(DateTime.Today.AddHours(7).AddMinutes(0), DateTime.Today.AddHours(7).AddMinutes(30)), doc, DateTime.Today.Date);
            Examination exam2 = new Examination(examRoom, false, "463155", AppointmentType.EXAMINATION, registeredPatient, new Term(DateTime.Today.AddHours(8).AddMinutes(0), DateTime.Today.AddHours(8).AddMinutes(30)), doc, DateTime.Today.Date);
            Examination exam3 = new Examination(examRoom, false, "282652", AppointmentType.EXAMINATION, registeredPatient, new Term(DateTime.Today.AddHours(15).AddMinutes(30), DateTime.Today.AddHours(16).AddMinutes(0)), doc, DateTime.Today.Date);

            ExaminationController examinationController = new ExaminationController(new ExaminationService(new ExaminationRepository(), new OperationRepository(), new DoctorRepository()));
            OperationController operationController = new OperationController(new OperationService(new OperationRepository()));

            examinationController.ScheduleExam(exam1);
            examinationController.ScheduleExam(exam2);
            examinationController.ScheduleExam(exam3);

            Operation oper1 = new Operation(operRoom, false, "2841241", AppointmentType.OPERATION, registeredPatient, new Term(DateTime.Today.AddHours(9).AddMinutes(0), DateTime.Today.AddHours(12).AddMinutes(0)), doc, DateTime.Today.Date);

            operationController.ScheduleOperation(oper1);


            AppointmentController appointmentController = new AppointmentController(new AppointmentService(new OperationRepository(), new ExaminationRepository(), new DoctorRepository()));
            
            List<Term> terms = appointmentController.GetAllDoctorsFreeTermsForToday(doc);

            foreach(Operation o in operationController.GetAllOperations())
            {
                Console.WriteLine("operacija " + o.Term.Start + " " + o.Term.End);
            }


            foreach(Examination e in examinationController.GetAllExaminations())
            {
                Console.WriteLine("OD " + e.Term.Start + "      DO: " + e.Term.End);
            }

            
            foreach (Term t in terms)
            {
                Console.WriteLine(t.Start + " " + t.End);
            }
      
        }*/

        static void LoadPatientsDoctorsMedicalDocumentation()
        {
            City city1 = new City("Beograd", 11195);
            State state1 = new State("Srbija");
            Address address1 = new Address("Dr Zorana Djindjica", 4);
            Location location1 = new Location(state1, city1, address1);

            City city2 = new City("Novi Sad", 21000);
            State state2 = new State("Srbija");
            Address address2 = new Address("Bulevar oslobodjenja", 15);
            Location location2 = new Location(state2, city2, address2);

            City city3 = new City("Subotica", 24000);
            State state3 = new State("Srbija");
            Address address3 = new Address("Ulica Miodraga Petrovica", 66);
            Location location3 = new Location(state3, city3, address3);

            City city4 = new City("Beckerek", 124912);
            State state4 = new State("Srbija");
            Address address4 = new Address("Ulica Milorada Pavica", 69);
            Location location4 = new Location(state4, city4, address4);

            City city = new City("Novi Sad", 21000);
            State state = new State("Serbia");
            Address address = new Address("Balzakova", 1);
            Location location = new Location(state, city, address);

            Account account1 = new Account("qp1234", "sifra1234");
            Account account2 = new Account("pq1234", "sifrasifra");
            Account account3 = new Account("radojko", "pitajKonobara");
            Account account4 = new Account("radovanC", "neDrzimKonsultacije");


            Account acc1 = new Account("pera", "pera123");
            Account acc2 = new Account("kris", "kris123");
            Account acc3 = new Account("mika", "mika123");


            NotificationController notificationController = new NotificationController(new NotificationService(new NotificationRepository()));
            Notification not1 = new Notification("12345", "not1", "", DateTime.Now, NotificationType.EMERGENCY_REQUEST);
            Notification not2 = new Notification("67890", "not2", "", DateTime.Now, NotificationType.EMERGENCY_REQUEST);
            Notification not3 = new Notification("123123456", "not3", "", DateTime.Now, NotificationType.EMERGENCY_REQUEST);
            notificationController.NewNotification(not1);
            notificationController.NewNotification(not2);
            notificationController.NewNotification(not3);
            DoctorController doctorController = new DoctorController(new DoctorService(new DoctorRepository()));

            Room examRoom1 = new Room("roomId1", "202", false, RoomType.EXAMROOM);
            Room examRoom2 = new Room("roomId2", "203", false, RoomType.EXAMROOM);
            Room examRoom3 = new Room("roomId3", "204", false, RoomType.EXAMROOM);

            Room operRoom1 = new Room("operId1", "OS1", false, RoomType.OPERATINGROOM);
            Room operRoom2 = new Room("operId2", "OS2", false, RoomType.OPERATINGROOM);
            Room operRoom3 = new Room("operId3", "OS3", false, RoomType.OPERATINGROOM);

            Doctor doctor1 = new Doctor("ORL", examRoom1, operRoom1, acc1, "Ivan", "Ivanic", "516511", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Perica", city, location);
            Doctor doctor2 = new Doctor("KARDIOLOG", examRoom2, operRoom2, acc2, "Jova", "Jovic", "686815", DateTime.Today.Date, "0601126849", "doctor@gmail.com", "Jovica", city1, location1);
            Doctor doctor3 = new Doctor("OPSTA_PRAKSA", examRoom3, operRoom3, acc3, "Ana", "Anic", "782527", DateTime.Today.Date, "061963582", "doc@gmail.com", "Anica", city2, location2);

            doctor1.Shifts.Add(new Shift(new DateTime(2020, 6, 30, 7, 0, 0), new DateTime(2020, 6, 30, 13, 0, 0)));
            doctor2.Shifts.Add(new Shift(new DateTime(2020, 6, 30, 7, 0, 0), new DateTime(2020, 6, 30, 13, 0, 0)));
            doctor3.Shifts.Add(new Shift(new DateTime(2020, 6, 30, 13, 0, 0), new DateTime(2020, 6, 30, 19, 0, 0)));

            for (int i = 1; i < 16; i++)
            {
                doctor1.Shifts.Add(new Shift(new DateTime(2020, 7, i, 7, 0, 0), new DateTime(2020, 7, i, 13, 0, 0)));
                doctor2.Shifts.Add(new Shift(new DateTime(2020, 7, i, 7, 0, 0), new DateTime(2020, 7, i, 13, 0, 0)));
                doctor3.Shifts.Add(new Shift(new DateTime(2020, 7, i, 13, 0, 0), new DateTime(2020, 7, i, 19, 0, 0)));
            }
            for (int i = 16; i < 32; i++)
            {
                doctor1.Shifts.Add(new Shift(new DateTime(2020, 7, i, 13, 0, 0), new DateTime(2020, 7, i, 19, 0, 0)));
                doctor2.Shifts.Add(new Shift(new DateTime(2020, 7, i, 13, 0, 0), new DateTime(2020, 7, i, 19, 0, 0)));
                doctor3.Shifts.Add(new Shift(new DateTime(2020, 7, i, 7, 0, 0), new DateTime(2020, 7, i, 13, 0, 0)));
            }
            doctorController.NewDoctor(doctor1);
            doctorController.NewDoctor(doctor2);
            doctorController.NewDoctor(doctor3);


            RegisteredPatient patient1 = new RegisteredPatient(doctor1, account1 ,"Pera", "Peric", "12345661", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Stevandza", city1, location1);
            RegisteredPatient patient2 = new RegisteredPatient(doctor2, account2, "Milisav", "Drakul", "01234012", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Milorad", city2, location2);
            RegisteredPatient patient3 = new RegisteredPatient(doctor3,account3, "Radojica", "Jovanovic", "09124712", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Perica", city2, location3);
            RegisteredPatient patient4 = new RegisteredPatient(doctor3, account4, "Radovan", "Turovic", "1020304050", new DateTime(2001,12,6), "06012498124", "radovan@gmail.com", "Perica", city4, location4);

            RegisteredPatientController registeredPatientController = new RegisteredPatientController(new RegisteredPatientService(new RegisteredPatientRepository(), new RegisteredUserRepository(), new PatientChartRepository()));
            registeredPatientController.NewRegisteredPatient(patient1);
            registeredPatientController.NewRegisteredPatient(patient2);
            registeredPatientController.NewRegisteredPatient(patient3);
            registeredPatientController.NewRegisteredPatient(patient4);

            PatientChartController patientChartController = new PatientChartController(new PatientChartService(new PatientChartRepository()));

            PatientChart patientChart1 = patientChartController.GetPatientChartByPatient(patient1);
            PatientChart patientChart2 = patientChartController.GetPatientChartByPatient(patient2);
            PatientChart patientChart3 = patientChartController.GetPatientChartByPatient(patient3);
            PatientChart patientChart4 = patientChartController.GetPatientChartByPatient(patient4);

            //dodavanje alergije
            patientChartController.AddAllergy(new Allergy("68165415", "Lesnik"), patientChart1);
            patientChartController.AddAllergy(new Allergy("89657416", "Polen"), patientChart1);

            patientChartController.AddAllergy(new Allergy("59783691", "Ambrozija"), patientChart2);

            patientChartController.AddAllergy(new Allergy("95871654", "Orah"), patientChart3);

            patientChartController.AddAllergy(new Allergy("96852647", "Polen"), patientChart4);

            //dodavanje terapije
            Drug drug1 = new Drug("12345678");
            Drug drug2 = new Drug("87654321");
            Drug drug3 = new Drug("14725836");
            Drug drug4 = new Drug("96857412");
            Drug drug5 = new Drug("32659810");
            Drug drug6 = new Drug("10101010");
            drug1.Name = "Brufen";
            drug2.Name = "Analgin";
            drug3.Name = "Xanax";
            drug4.Name = "Bromazepam";
            drug5.Name = "Bensedin";
            drug6.Name = "Strepsils";

            DrugController drugController = new DrugController(new DrugServices(new DrugRepository()));
            drugController.Add(drug1);
            drugController.Add(drug2);
            drugController.Add(drug3);
            drugController.Add(drug4);
            drugController.Add(drug5);
            drugController.Add(drug6);

            TherapyController therapyController = new TherapyController(new TherapyService(new TherapyRepository()));

            PrescribedDrug prescribedDrug1 = new PrescribedDrug("2134978961", DateTime.Today, DateTime.Today.AddDays(2), 3, drug1);
            PrescribedDrug prescribedDrug2 = new PrescribedDrug("6648515152", DateTime.Today, DateTime.Today.AddDays(3), 2, drug2);
            PrescribedDrug prescribedDrug3 = new PrescribedDrug("9846515152", DateTime.Today, DateTime.Today.AddDays(4), 1, drug3);
            PrescribedDrug prescribedDrug4 = new PrescribedDrug("9843515123", DateTime.Today, DateTime.Today.AddDays(5), 4, drug4);
            PrescribedDrug prescribedDrug5 = new PrescribedDrug("9465151513", DateTime.Today, DateTime.Today.AddDays(6), 2, drug5);
            PrescribedDrug prescribedDrug6 = new PrescribedDrug("9851351623", DateTime.Today, DateTime.Today.AddDays(7), 3, drug6);
            PrescribedDrug prescribedDrug7 = new PrescribedDrug("9842464561", DateTime.Today, DateTime.Today.AddDays(8), 4, drug1);
            PrescribedDrug prescribedDrug8 = new PrescribedDrug("6898918514", DateTime.Today, DateTime.Today.AddDays(9), 1, drug2);
            List<PrescribedDrug> prescribedDrugs1 = new List<PrescribedDrug>();
            prescribedDrugs1.Add(prescribedDrug1);
            prescribedDrugs1.Add(prescribedDrug2);

            List<PrescribedDrug> prescribedDrugs2 = new List<PrescribedDrug>();
            prescribedDrugs2.Add(prescribedDrug3);
            prescribedDrugs2.Add(prescribedDrug4);

            List<PrescribedDrug> prescribedDrugs3 = new List<PrescribedDrug>();
            prescribedDrugs3.Add(prescribedDrug5);
            prescribedDrugs3.Add(prescribedDrug6);

            List<PrescribedDrug> prescribedDrugs4 = new List<PrescribedDrug>();
            prescribedDrugs4.Add(prescribedDrug7);
            prescribedDrugs4.Add(prescribedDrug8);

            List<PrescribedDrug> prescribedDrugs5 = new List<PrescribedDrug>();
            prescribedDrugs5.Add(prescribedDrug1);
            prescribedDrugs5.Add(prescribedDrug3);

            List<PrescribedDrug> prescribedDrugs6 = new List<PrescribedDrug>();
            prescribedDrugs6.Add(prescribedDrug4);
            prescribedDrugs6.Add(prescribedDrug6);

            Therapy therapy1 = new Therapy(DateTime.Today, "12346578", prescribedDrugs1, patientChart1);
            Therapy therapy2 = new Therapy(DateTime.Today, "61516515", prescribedDrugs2, patientChart1);
            Therapy therapy3 = new Therapy(DateTime.Today, "28543535", prescribedDrugs3, patientChart1);
            Therapy therapy4 = new Therapy(DateTime.Today, "45354355", prescribedDrugs4, patientChart2);
            Therapy therapy5 = new Therapy(DateTime.Today, "45354345", prescribedDrugs5, patientChart2);
            Therapy therapy6 = new Therapy(DateTime.Today, "45354534", prescribedDrugs6, patientChart3);
            Therapy therapy7 = new Therapy(DateTime.Today, "45453543", prescribedDrugs1, patientChart3);
            Therapy therapy8 = new Therapy(DateTime.Today, "45354535", prescribedDrugs1, patientChart4);
            Therapy therapy9 = new Therapy(DateTime.Today, "45345345", prescribedDrugs4, patientChart4);

            therapyController.WriteTherapy(therapy1);
            therapyController.WriteTherapy(therapy2);
            therapyController.WriteTherapy(therapy3);
            therapyController.WriteTherapy(therapy4);
            therapyController.WriteTherapy(therapy5);
            therapyController.WriteTherapy(therapy6);
            therapyController.WriteTherapy(therapy7);
            therapyController.WriteTherapy(therapy8);
            therapyController.WriteTherapy(therapy9);

            //reportOfExaminations
            ReportOfExaminationController reportOfExaminationController = new ReportOfExaminationController(new ReportOfExaminationService(new ReportOfExaminationRepository()));
            ReportOfExamination reportOfExamination1 = new ReportOfExamination("Pacijent je dosao sa temperaturom", "COVID-19", "Temperatura", new DateTime(2020, 5, 2), "563515", patientChart1);
            ReportOfExamination reportOfExamination2 = new ReportOfExamination("Pacijent se zali na bol u prstu", "Prelom prsta", "Bol u prstu", new DateTime(2020, 4, 1), "275752", patientChart1);
            ReportOfExamination reportOfExamination3 = new ReportOfExamination("Pacijent se zali na bol u grlu", "Upala grla", "Bol u grlu", new DateTime(2020, 3, 22), "541655", patientChart1);
            ReportOfExamination reportOfExamination4 = new ReportOfExamination("Pacijent se zali da mu boli glava i curi nos", "Grip", "Temperatura", new DateTime(2020, 5, 2), "48535434", patientChart2);
            ReportOfExamination reportOfExamination5 = new ReportOfExamination("Pacijent se zali na bol u grlu i bol u vratu", "Upala krajnika", "Bol u grlu", new DateTime(2020, 4, 12), "45354354", patientChart2);
            ReportOfExamination reportOfExamination6 = new ReportOfExamination("Pacijent se zali na malaksalost i pospanost", "Hipertireoza", "Malaksalost", new DateTime(2020, 3, 16), "9687375", patientChart2);
            ReportOfExamination reportOfExamination7 = new ReportOfExamination("Pacijent se zali na glavobolju i ima povisen pritisak vec duze vreme", "Hipertenzija", "Povisen pritisak", new DateTime(2020, 5, 12), "753837", patientChart3);
            ReportOfExamination reportOfExamination8 = new ReportOfExamination("Pacijent se zali na malaksalost", "Mononukleoza", "Malaksalost", new DateTime(2020, 4, 29), "293575", patientChart3);
            ReportOfExamination reportOfExamination9 = new ReportOfExamination("Pacijent je dosao sa temperaturom", "COVID-19", "Temperatura", new DateTime(2020, 4, 12), "537575", patientChart3);
            ReportOfExamination reportOfExamination10 = new ReportOfExamination("Pacijent se zali na bol u grlu", "Upala grla", "Bol u grlu", new DateTime(2020, 5, 9), "5373838", patientChart4);
            ReportOfExamination reportOfExamination11 = new ReportOfExamination("Pacijent se zali da mu boli glava ali bez temperature i curi mu nos", "Grip", "Temperatura", new DateTime(2020, 4, 2), "375787", patientChart4);
            ReportOfExamination reportOfExamination12 = new ReportOfExamination("Pacijent se zali na bol duz noge vec par dana", "Prelom noge", "Bol duz noge", new DateTime(2020, 3, 17), "656516", patientChart4);
            reportOfExaminationController.WriteReportOfExamination(reportOfExamination1);
            reportOfExaminationController.WriteReportOfExamination(reportOfExamination2);
            reportOfExaminationController.WriteReportOfExamination(reportOfExamination3);
            reportOfExaminationController.WriteReportOfExamination(reportOfExamination4);
            reportOfExaminationController.WriteReportOfExamination(reportOfExamination5);
            reportOfExaminationController.WriteReportOfExamination(reportOfExamination6); 
            reportOfExaminationController.WriteReportOfExamination(reportOfExamination7);
            reportOfExaminationController.WriteReportOfExamination(reportOfExamination8);
            reportOfExaminationController.WriteReportOfExamination(reportOfExamination9); 
            reportOfExaminationController.WriteReportOfExamination(reportOfExamination10);
            reportOfExaminationController.WriteReportOfExamination(reportOfExamination11);
            reportOfExaminationController.WriteReportOfExamination(reportOfExamination12);

            //dodavanje recepta
            Prescription p1 = new Prescription("2 put dnevno", new DateTime(2020, 5, 2), "287553", drug1, patientChart1);
            Prescription p2 = new Prescription("3 put dnevno", new DateTime(2020, 4, 12), "893534", drug2, patientChart1);
            Prescription p3 = new Prescription("Jednom dnevno pre spavanja", new DateTime(2020, 5, 2), "453454", drug3, patientChart2);
            Prescription p4 = new Prescription("2 puta dnevno posle jela", new DateTime(2020, 4, 3), "453434", drug4, patientChart2);
            Prescription p5 = new Prescription("3 puta dnevno", new DateTime(2020, 5, 2), "453453", drug5, patientChart3);
            Prescription p6 = new Prescription("2 puta dnevno", new DateTime(2020, 4, 21), "2345343", drug6, patientChart3);
            Prescription p7 = new Prescription("Jednom dnevno posle dorucka", new DateTime(2020, 5, 2), "454345", drug3, patientChart4);
            Prescription p8 = new Prescription("3 puta dnevno", new DateTime(2020, 4, 24), "543534", drug5, patientChart4);

            PrescriptionController pr = new PrescriptionController(new Service.ServiceMedicalDocumentation.PrescriptionService(new PrescriptionRepository()));
            pr.WritePrescription(p1);
            pr.WritePrescription(p2);
            pr.WritePrescription(p3);
            pr.WritePrescription(p4);
            pr.WritePrescription(p5);
            pr.WritePrescription(p6);
            pr.WritePrescription(p7);
            pr.WritePrescription(p8);

            //dodavanje uputa
            ReferralLetterController refLetCont = new ReferralLetterController(new Service.ServiceMedicalDocumentation.ReferralLetterService(new ReferralLetterRepository()));

            ReferralLetter referralLetter1 = new ReferralLetter("Potreban dalji pregled", new DateTime(2020, 5, 2), "23312145", patientChart1, doctor1);
            ReferralLetter referralLetter2 = new ReferralLetter("Zabrinjavajuce psihicko stanje", new DateTime(2020, 4, 21), "94812311", patientChart1, doctor2);
            ReferralLetter referralLetter3 = new ReferralLetter("Potreban dalji pregled i laboratorijski nalaz", new DateTime(2020, 3, 22), "12213231", patientChart2, doctor1);
            ReferralLetter referralLetter4 = new ReferralLetter("Potrebno uraditi dalja istrazivanja", new DateTime(2020, 3, 2), "21312313", patientChart2, doctor2);
            ReferralLetter referralLetter5 = new ReferralLetter("Potreban dalji pregled i laboratorijski nalaz", new DateTime(2020, 5, 2), "1231231", patientChart3, doctor1);
            ReferralLetter referralLetter6 = new ReferralLetter("Potreban dalji pregled", new DateTime(2020, 4, 2), "8481", patientChart3, doctor2);
            ReferralLetter referralLetter7 = new ReferralLetter("Zabrinjavajuce zdravstveno stanje", new DateTime(2020, 5, 2), "1231232", patientChart4, doctor1);
            ReferralLetter referralLetter8 = new ReferralLetter("Potreban dalji pregled", new DateTime(2020, 4, 22), "6345435", patientChart4, doctor2);
            refLetCont.WriteReferralLetter(referralLetter1);
            refLetCont.WriteReferralLetter(referralLetter2);
            refLetCont.WriteReferralLetter(referralLetter3);
            refLetCont.WriteReferralLetter(referralLetter4);
            refLetCont.WriteReferralLetter(referralLetter5);
            refLetCont.WriteReferralLetter(referralLetter6);
            refLetCont.WriteReferralLetter(referralLetter7);
            refLetCont.WriteReferralLetter(referralLetter8);

            DrugApproval drugApproval1 = new DrugApproval("Zahtev za odobravanje brufena","Sastojci: penicilin 50 mg...", "654651", drug1);
            DrugApproval drugApproval2 = new DrugApproval("Zahtev za odobravanje analgina","Sastojci: penicilin 50 mg...", "165154", drug2);
            DrugApproval drugApproval3 = new DrugApproval("Zahtev za odobravanje xanaxa","Sastojci: penicilin 50 mg...", "681468", drug3);

            ApprovalController approvalController = new ApprovalController(new ApprovalServices(new ApprovalRepository(new DrugRepository()), new DrugServices(new DrugRepository())));


            approvalController.Add(drugApproval1);
            approvalController.Add(drugApproval2);
            approvalController.Add(drugApproval3);
    
            Console.WriteLine("Ucitano");

        }
        //(ALEKSANDAR)
        static void LoadBlog()
        {
            DoctorController doctorController = new DoctorController(new Service.ServiceDoctor.DoctorService(new DoctorRepository()));
            RegisteredPatientController registeredPatientController = new RegisteredPatientController(new RegisteredPatientService(new RegisteredPatientRepository(), new RegisteredUserRepository(), new PatientChartRepository()));
            QuestionController questionController = new QuestionController(new QuestionService(new QuestionsRepository()));
            BlogArticleController blogArticleController = new BlogArticleController(new BlogArticleService(new BlogArticlesRepository()));



            List<RegisteredPatient> patients = registeredPatientController.GetAll();
            List<Doctor> doctors = doctorController.GetAllDoctors();
            

            BlogArticle blogArticle1 = new BlogArticle("Clanak o alergenima", doctors[0], "id1", "Izlaganje alergenima je vrlo opasno po osobe koje pate od alergije. Cak i najmanje izlaganje alergenima moze da izazove velike posledice, pa cak i smrtan ishod kod alergicnih osoba. Preporuceno je da pacijenti se drzi podalje od alergena koji mogu da ugroze njihovo zdravlje i na taj nacin natovare dodatnog posla medicinarima i grobarima.", DateTime.Now);
            BlogArticle blogArticle2 = new BlogArticle("Clanak o maskama i koroni", doctors[1], "id2", "S obzirom na opstu famu oko covid19 virusa, nosenje maske je postalo obavezno u svim zatvorenim prostorima. Postavlja se pitanje zasto bismo nosili maske ukoliko niko drugi ne nosi maske, jer one druge stite od nas, a ne obrnuto. Jos je bitno istaci da postoji vise vrsta maski i da obicne medicinske koje se kuopuju za 100din ne rade isti posao i traju max 4h, za razliku od pravih maski koje koriste medicinski radnici. Maske nisu efektivne ako se diraju rukama u podrucju usta i efektivnost maski se dosta snizava, ukoliko se ostali delovi tela koji su izlozeni ne pokrivaju (oci, usi, koza,kosa...)", DateTime.Now);
            BlogArticle blogArticle3 = new BlogArticle("Clanak o bolu u grudima", doctors[2], "id3", "Veoma bitno je zapamtiti da svaki bol u grudima nije infarkt. Iako je simptom isti, uzroci mogu varirati od sitnica, do veoma ozbiljnih stvari koje se zavrsavaju smrtim ishodom. Kako se ne bi pri svakom najmanjem bolu panicilo, potrebno je da se prepozna o kakvom obliku boli se radi. U slucaju da je to bol ostar i preslikava se kroz ceo grudni kos, na ledja, onda se vrlo verovatno radi o pogresnom polozaju kicme ili o nazebu od promHe.", DateTime.Now);
            blogArticleController.NewArticle(blogArticle1);
            blogArticleController.NewArticle(blogArticle2);
            blogArticleController.NewArticle(blogArticle3);


            Question question1 = new Question("Pitanje o koroni?", patients[0], "qId1", "Sta mogu da uradim da se zastitim od corone?", DateTime.Today);
            Question question2 = new Question("Pitanje o vakcini za koronu?", patients[1], "qId2", "Da li postoji vakcina za koronu?", DateTime.Today);


            Answer answer1 = new Answer(doctors[1], "pId1", "Mozete da drzite distancu od ljudi, izbegavate velika okupljanja, nosite maske u zatvorenom prostoru i ne verujete vladi republike srbije.", DateTime.Now);
            Answer answer2 = new Answer(doctors[1], "pId2", "Do sada ne postoji vakcija. Trenutno se vrse masovna testiranja vakcine, bice razvijena u najkracem mogucem roku. Laboratorija u nasoj Klinici Zdravo prognozira vakcinu sledece nedelje.", DateTime.Now);

            question1.Answer = answer1;
            question1.Answered = true;

            question2.Answer = answer2;
            question2.Answered = true;

            questionController.AskQuestion(question1);
            questionController.AskQuestion(question2);

            Console.WriteLine("Ucitano");

        }

        static void LoadRatings()
        {
            DoctorController doctorController = new DoctorController(new Service.ServiceDoctor.DoctorService(new DoctorRepository()));
            RegisteredPatientController registeredPatientController = new RegisteredPatientController(new RegisteredPatientService(new RegisteredPatientRepository(), new RegisteredUserRepository(), new PatientChartRepository()));

            List<RegisteredPatient> patients = registeredPatientController.GetAll();
            List<Doctor> doctors = doctorController.GetAllDoctors();

            RatingsController RatingController = new RatingsController(new RatingsService(new RatingsRepository()));

            RatingController.RateDoctor(new Rating("rId1", RatingValue.five, " Odlican gari skroz!" ,doctors[0], patients[0]));
            RatingController.RateDoctor(new Rating("rId2", RatingValue.one, "Ocajan lik!", doctors[0], patients[1]));
            RatingController.RateDoctor(new Rating("rId3", RatingValue.two, " Nije nis posebno!", doctors[1], patients[1]));
            RatingController.RateDoctor(new Rating("rId4", RatingValue.four, " Skoro sam skroz zadovoljan radom!", doctors[2], patients[1]));
            RatingController.RateDoctor(new Rating("rId5", RatingValue.one, " U Z A S!", doctors[1], patients[2]));


            NotificationController notificationController = new NotificationController(new NotificationService(new NotificationRepository()));

            Notification notification1 = new Notification(patients[1], "notif1", "Vas pregled je pomeren na 25.7. u 19h.", new DateTime(2020, 6, 25));
            Notification notification2 = new Notification(patients[2], "notif2", "Vas pregled je pomeren na 15.7. u 19h.", new DateTime(2020, 6, 27));
            Notification notification3 = new Notification(patients[1], "notif3", "Vas zahtev za hitan pregled je odobren. Pregled ce biti odrzan 23.6. u 12h u prostoriji 202.", new DateTime(2020, 6, 22));

            notificationController.NewNotification(notification1);
            notificationController.NewNotification(notification2);
            notificationController.NewNotification(notification3);

            Console.WriteLine("Ucitano");
        }
        static void AccountShit()
        {
            City city = new City("Kekenda", 21000);
            State state = new State("Vodzvodina");
            Address address = new Address("Legijina", 1);
            Location location = new Location(state, city, address);

            Account acc2 = new Account("kris", "kris");
            Room examRoom1 = new Room("roomId1", "202", false, RoomType.EXAMROOM);
            Room operRoom1 = new Room("operId1", "202", false, RoomType.OPERATINGROOM);

            Doctor doc1 = new Doctor("orl", examRoom1, operRoom1, acc2, "Kris", "Peric", "123141", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Perica", city, location);

            Account account = new Account("qp1234", "sifra");
            Person person = new Person("Pera", "Peric", "123141", DateTime.Today.Date, "0606442234", "asfasf@gmail.com", "Perica", city, location);

            UserController uCntr = new UserController(new UserService(new RegisteredUserRepository(), new BlogArticlesRepository(), new QuestionsRepository(), new PersonRepository()));
            RegisteredUserController registeredUserController = new RegisteredUserController(new RegisteredUserService(new RegisteredUserRepository(), new FeedbackRepository()));

            RegisteredUser registeredUser = uCntr.SignUp(account, person);
            Console.WriteLine();
            Console.WriteLine("Registracija: ");
            Console.WriteLine("Unesite username: ");
            string username = Console.ReadLine();

            Console.WriteLine("Unesite passwrod: ");
            Console.WriteLine();

            string password = Console.ReadLine();
            City zemun = new City("Zemun", 21000);
            State srJug = new State("SR Jugoslavija");
            Address adresa = new Address("Silerova ", 6);
            Location lokacija = new Location(state, city, address);

            Console.WriteLine("Unesite id za lika");
            string id = Console.ReadLine();

            Person regPerson = new Person("Dusan", "Spasojevic", id, DateTime.Today.Date, "124109124", "siptar@gmail.com", "Siptar", zemun, lokacija);

            RegisteredUser user = uCntr.SignUp(uCntr.CreateAccount(username, password), regPerson);

            foreach (RegisteredUser u in new RegisteredUserRepository().GetAll())
            {
                Console.WriteLine(u.Account.Username);
                Console.WriteLine(u.Account.Password);
                Console.WriteLine("-----------------");
            }
            Console.WriteLine("-----------------");
            Console.WriteLine();

            Console.WriteLine("Logovanje: ");
            Console.WriteLine("Unesite username: ");
            username = Console.ReadLine();

            Console.WriteLine("Unesite passwrod: ");
            password = Console.ReadLine();

            RegisteredUser logedIn = registeredUserController.Login(new Account(username, password));
            Console.WriteLine(logedIn.Name);
            Console.WriteLine(logedIn.Surname);
            Console.WriteLine(logedIn.ParentName);
            Console.WriteLine("-----------------");
            Console.WriteLine();
            Console.WriteLine("Test izmene sifre: -----------");
            Console.WriteLine("Unesite username:");
            username = Console.ReadLine();
            Console.WriteLine("Unesite novu sifru:");
            password = Console.ReadLine();

            registeredUserController.ChangePassword(password, registeredUserController.GetRegisteredUserByUsername(username));

            foreach (RegisteredUser u in new RegisteredUserRepository().GetAll())
            {
                Console.WriteLine(u.Account.Username);
                Console.WriteLine(u.Account.Password);
                Console.WriteLine("-----------------");
            }
        }
        static void FeedbackShit()
        {
            RegisteredUserController registeredUserController = new RegisteredUserController(new RegisteredUserService(new RegisteredUserRepository(), new FeedbackRepository()));

            List<RegisteredUser> registeredUsers = registeredUserController.GetAll();

            Feedback f1 = new Feedback(registeredUsers[0], "feedbackId1", "Ova apk kida skroz", DateTime.Now);
            Feedback f2 = new Feedback(registeredUsers[1], "feedbackId2", "Ova apk nije okej jako me smara skroz", DateTime.Now);
            //Feedback f3 = new Feedback(registeredUsers[2], "feedbackId3", "Neobavesten sam ko kostunica", DateTime.Now);

            registeredUserController.PostFeedback(f1);

            List<Feedback> feedbacks = registeredUserController.GetFeedbacks();

            foreach (Feedback f in feedbacks)
            {
                Console.WriteLine(f.Text);
                Console.WriteLine("-----------------");
            }

            registeredUserController.PostFeedback(f2);
            //registeredUserController.PostFeedback(f3);

            foreach (Feedback f in registeredUserController.GetFeedbacks())
            {
                Console.WriteLine(f.Text);
                Console.WriteLine("-----------------");
            }


        }


        //(RADOVAN) sekretar 

        static void CreatePatientAccount()
        {
            Console.WriteLine("\t***KREIRAJ NALOG PACIJENTU***");
            Console.WriteLine("1. Pacijent vec postoji u evidenciji");
            Console.WriteLine("2. Pacijent je prvi put u klinici");
            Console.WriteLine("0. Nazad");
            int command = insertCommand();

            if (command == 0) return;
            else if (command == 1) MakeAccountForKnownPatient();
            else if (command == 2) MakeAccountForUnknownPatient();
            Console.WriteLine("------------------------------------------------------------------");
        }

        static Person IntroduceYourself()
        {
            Console.WriteLine("Unesite ime:");
            string name = Console.ReadLine();
            Console.WriteLine("Unesite prezime:");
            string surname = Console.ReadLine();
            Console.WriteLine("Unesite jmbg:");
            string pin = Console.ReadLine();
            Console.WriteLine("Unesite datum rodjenja:");
            string date = Console.ReadLine();
            DateTime dt;
            while (!DateTime.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Pogresno unesen datum, probajte ponovo (dd/MM/yyyy)");
                date = Console.ReadLine();
            }
            Console.WriteLine(dt.ToString());
            Console.WriteLine("Unesite broj telefona:");
            string phone = Console.ReadLine();
            Console.WriteLine("Unesite email:");
            string email = Console.ReadLine();
            Console.WriteLine("Unesite ime roditelja:");
            string parentName = Console.ReadLine();
            Console.WriteLine("Unesite ime grada:");
            string cityName = Console.ReadLine();
            int cityPin = 0;
            Console.WriteLine("Unesite postanski broj:");
            while (!Int32.TryParse(Console.ReadLine(), out cityPin))
            {
                Console.WriteLine("Postanski broj neispravan (samo brojevi)");
            }
            City city = new City(cityName.Trim(), cityPin);
            Console.WriteLine("Unesite ime drzave:");
            string stateName = Console.ReadLine();
            State state = new State(stateName.Trim());
            Console.WriteLine("Unesite ime ulice:");
            string streetName = Console.ReadLine();
            int streetNumber = 0;
            Console.WriteLine("Unesite broj ulice:");
            while (!Int32.TryParse(Console.ReadLine(), out streetNumber))
            {
                Console.WriteLine("Broj ulice neispravan (samo brojevi)");
            }
            Address address = new Address(streetName.Trim(), streetNumber);
            Location location = new Location(state, city, address);
            return new Person(name.Trim(), surname.Trim(), pin.Trim(), dt, phone.Trim(), email.Trim(), parentName.Trim(), city, location);
        }
        static void MakeAccountForUnknownPatient()
        {
            UserController userController = new UserController(new UserService(new RegisteredUserRepository(), new BlogArticlesRepository(),
                new QuestionsRepository(), new PersonRepository()));
            Person person = IntroduceYourself();
            while (true)
            {
                Console.WriteLine("Unesite korisnicko ime:");
                string username = Console.ReadLine();
                Console.WriteLine("Unesite lozinku:");
                string password = Console.ReadLine();
                Account account = userController.CreateAccount(username, password);
                if (account != null)
                {
                    RegisteredUser registeredUser = userController.SignUp(account, person);
                    DoctorController doctorController = new DoctorController(new DoctorService(new DoctorRepository()));
                    RegisteredPatientController registeredPatientController = new RegisteredPatientController(new RegisteredPatientService(new RegisteredPatientRepository(), new RegisteredUserRepository(), new PatientChartRepository()));
                    DoctorAggregate doctors = new DoctorAggregate(doctorController.GetAllDoctors());
                    var iterator = doctors.CreateIterator();
                    Doctor doc = null;
                    while(doc == null)
                    {
                        Console.WriteLine("Odaberite Lekara:");
                        int i = 1;
                        while (iterator.IsDone()) Console.WriteLine(i++ + ". " + iterator.CurrentItem().Name + " " + iterator.CurrentItem().Surname);
                        int command = insertCommand();
                        doc = iterator.GetItem(command - 1);
                    }

                    bool success = registeredPatientController.ConvertRegisteredUserToRegisteredPatient(doc, registeredUser);
                    if(success)
                    {
                        Console.WriteLine("------------------------------------------------------------------");
                        Console.WriteLine("Nalog uspesno kreiran");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("------------------------------------------------------------------");
                        Console.WriteLine("Doslo je do greske prilikom kreiranja naloga, pokusajte ponovo");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("------------------------------------------------------------------");
                    Console.WriteLine("Korisnicko ime je vec zauzeto, pokusajte ponovo");
                }
            }

        }
        static void MakeAccountForKnownPatient()
        {
            UserController userController = new UserController(new UserService
                (new RegisteredUserRepository(), new BlogArticlesRepository(),
                new QuestionsRepository(), new PersonRepository()));
            string username = "";
            string password = "";
            Console.WriteLine("Unesite pin pacijenta:");
            string pin = Console.ReadLine();
            Person person = userController.GetKnownPerson(pin.Trim());
            if (person == null)
                Console.WriteLine("Pacijent sa unetim pinom ne postoji u evidenciji");
            else
            {
                Console.WriteLine("Unesite korisnicko ime:");
                username = Console.ReadLine();
                Console.WriteLine("Unesite lozinku:");
                password = Console.ReadLine();
                Account account = new Account(username.Trim(), password.Trim());
                RegisteredUser registeredUser = userController.CreateRegisteredUserOfKnownPerson(person.Pin, account);
                if (registeredUser != null)
                {
                    DoctorController doctorController = new DoctorController(new DoctorService(new DoctorRepository()));
                    RegisteredPatientController registeredPatientController = new RegisteredPatientController(new RegisteredPatientService(new RegisteredPatientRepository(), new RegisteredUserRepository(), new PatientChartRepository()));
                    DoctorAggregate doctors = new DoctorAggregate(doctorController.GetAllDoctors());
                    var iterator = doctors.CreateIterator();
                    Doctor doc = null;
                    while (doc == null)
                    {
                        Console.WriteLine("Odaberite Lekara:");
                        int i = 1;
                        while (iterator.IsDone()) Console.WriteLine(i++ + ". " + iterator.CurrentItem().Name + " " + iterator.CurrentItem().Surname);
                        int command = insertCommand();
                        doc = iterator.GetItem(command - 1);
                    }

                    bool success = registeredPatientController.ConvertRegisteredUserToRegisteredPatient(doc, registeredUser);
                    if (success)
                    {
                        Console.WriteLine("------------------------------------------------------------------");
                        Console.WriteLine("Nalog uspesno kreiran");
                    }
                    else
                    {
                        Console.WriteLine("------------------------------------------------------------------");
                        Console.WriteLine("Doslo je do greske prilikom kreiranja naloga, pokusajte ponovo");
                    }
                }
                else
                {
                    Console.WriteLine("------------------------------------------------------------------");
                    Console.WriteLine("Nalog nije uspesno kreiran(korisnicko ime vec postoji)");
                }

            }
        }


        static void ChangePatientPassword()
        {
            RegisteredUserController registeredUserController = new RegisteredUserController(new RegisteredUserService(new RegisteredUserRepository(), new FeedbackRepository()));
            Console.WriteLine("\t***PROMENI LOZINKU PACIJENTU***");
            while (true)
            {
                Console.WriteLine("Unesite korisnicko ime pacijenta:");
                string username = Console.ReadLine();
                if (username.Equals("0")) return;
                RegisteredUser registeredUser = registeredUserController.GetRegisteredUserByUsername(username.Trim());
                if (registeredUser == null)
                {
                    Console.WriteLine("Odabrani username ne postoji!");
                    Console.WriteLine("Molim Vas ponovite!");
                }
                else
                {
                    Console.WriteLine("Unesite novu lozinku(min 5 karaktera):");
                    string password = Console.ReadLine();
                    registeredUserController.ChangePassword(password, registeredUser);
                    Console.WriteLine("Uspesno ste promenili lozinku!");
                    break;
                }
                Console.WriteLine("------------------------------------------------------------------");

            }

        }
        static void CreateSecretaryReport()
        {
            int command = 0;
            Console.WriteLine("\t***NAPRAVI IZVESTAJ***");
            Console.WriteLine("1. Izvestaj o svim intervencijama");
            Console.WriteLine("2. Izvestaj o operacionoj sali");
            Console.WriteLine("3. Izvestaj o lekaru");
            Console.WriteLine("0. Izlaz");
            command = insertCommand();
            Console.WriteLine("------------------------------------------------------------------");
            switch (command)
            {
                case 1:
                    MakeInterventionReport();
                    break;
                case 2:
                    MakeOperationRoomReport();
                    break;
                case 3:
                    MakeDoctorReport();
                    break;
                case 0:
                    break;
            }
        }

        static void MakeInterventionReport()
        {
            Console.WriteLine("\t***IZVESTAJ O INTERVENCIJAMA***");
            string dateInterval = "";
            ExaminationController examinationController = new ExaminationController(new ExaminationService(new ExaminationRepository(), new OperationRepository(), new DoctorRepository()));
            DoctorController doctorController = new DoctorController(new DoctorService(new DoctorRepository()));
            RegisteredPatientController registeredPatientController = new RegisteredPatientController(new RegisteredPatientService(new RegisteredPatientRepository(),new RegisteredUserRepository(), new PatientChartRepository()));
            OperationController operationController = new OperationController(new OperationService(new OperationRepository()));
            while (true)
            {
                Console.WriteLine("Unesite vremenski interval (dd/MM/yyyy-dd/MM/yyyy):");
                dateInterval = Console.ReadLine();
                if(!dateInterval.Contains("-") && (dateInterval.Length != 21) )
                {
                    Console.WriteLine("Pogresan unos datuma pokusajte ponovo");
                }
                else
                {
                    string[] dates = dateInterval.Split('-');
                    string[] start = dates[0].Split('/');
                    string[] end = dates[1].Split('/');
                    Console.WriteLine(start[0] + " " + start[1] + " "+ start[2]);
                    DateTime startDate = new DateTime(int.Parse(start[2]), int.Parse(start[1]), int.Parse(start[0]), 0, 0, 0);
                    DateTime endDate = new DateTime(int.Parse(end[2]), int.Parse(end[1]), int.Parse(end[0]), 23, 59, 59);

                    ExamAggregate exams = new ExamAggregate(examinationController.GetAllExamsForTimePeriod(startDate, endDate));
                    var iteratorExams = exams.CreateIterator();
                    if(exams.Count() > 0)
                    {

                        Console.WriteLine("\t***Pregledi***");
                        while(iteratorExams.IsDone())
                        {
                            Doctor doctor = doctorController.GetDoctorById(iteratorExams.CurrentItem().Doctor.Pin);
                            RegisteredPatient registeredPatient = registeredPatientController.Get(iteratorExams.CurrentItem().RegisteredPatient.Pin);
                            Console.WriteLine(doctor.Name + " " 
                                + doctor.Surname + " " 
                                + iteratorExams.CurrentItem().Date.Date + " " 
                                + registeredPatient.Name + " " 
                                + registeredPatient.Surname + " "
                                + iteratorExams.CurrentItem().Term.Start) ;
                        }
                    }


                    OperationAggregate operations = new OperationAggregate(operationController.GetAllOperationForTimePeriod(startDate, endDate));
                    var iteratorOperation = operations.CreateIterator();
                    if(operations.Count() > 0)
                    {
                        Console.WriteLine("\t***Operacije***");
                        while (iteratorOperation.IsDone())
                        {
                            Doctor doctor = doctorController.GetDoctorById(iteratorOperation.CurrentItem().Doctor.Pin);
                            RegisteredPatient registeredPatient = registeredPatientController.Get(iteratorOperation.CurrentItem().RegisteredPatient.Pin);
                            Console.WriteLine(doctor.Name + " "
                                + doctor.Surname + " "
                                + iteratorOperation.CurrentItem().Date.Date + " "
                                + registeredPatient.Name + " "
                                + registeredPatient.Surname + " "
                                + iteratorOperation.CurrentItem().Term.Start);
                        }
                    }

                    if(operations.Count() < 1 && exams.Count() < 1)
                    {
                        Console.WriteLine("Nema intervencija za uneti period");
                    }

                    Console.WriteLine("------------------------------------------------------------------");
                    return;

                }
            }    


        }

        static void MakeOperationRoomReport()
        {
            Console.WriteLine("\t***IZVESTAJ O OPERACIONOJ SALI***");
            Console.WriteLine("Odaberite operacionu salu:");
            OperationRoomController operationRoomController = new OperationRoomController(new OperatingRoomService(new OperationRoomRepository()));
            List<Room> rooms = operationRoomController.GetAll();
            int i = 1;
            foreach(Room room in rooms)
            {
                Console.WriteLine(i++ + ". " + "("+room.Id+") " + room.Name);
            }
            Console.WriteLine("0. Izlaz");
            int command = insertCommand();
            if (command == 0) return;
            Room rm = rooms[command - 1];
            PrintAllOperationFromRoom(rm);

        }
        
        static void PrintAllOperationFromRoom(Room room)
        {
            OperationController operationController = new OperationController(new OperationService(new OperationRepository()));
            DoctorController doctorController = new DoctorController(new DoctorService(new DoctorRepository()));
            RegisteredPatientController registeredPatientController = new RegisteredPatientController(new RegisteredPatientService(new RegisteredPatientRepository(), new RegisteredUserRepository(), new PatientChartRepository()));

            string dateInterval;
            while (true)
            {
                Console.WriteLine("Unesite vremenski interval (dd/MM/yyyy-dd/MM/yyyy):");
                dateInterval = Console.ReadLine();
                if (!dateInterval.Contains("-") && (dateInterval.Length != 21))
                {
                    Console.WriteLine("Pogresan unos datuma pokusajte ponovo");
                }
                else
                {
                    string[] dates = dateInterval.Split('-');
                    string[] start = dates[0].Split('/');
                    string[] end = dates[1].Split('/');
                    Console.WriteLine(start[0] + " " + start[1] + " " + start[2]);
                    DateTime startDate = new DateTime(int.Parse(start[2]), int.Parse(start[1]), int.Parse(start[0]), 0, 0, 0);
                    DateTime endDate = new DateTime(int.Parse(end[2]), int.Parse(end[1]), int.Parse(end[0]), 23, 59, 59);

                    Console.WriteLine("Operacije za salu " + room.Id);
                    OperationAggregate operations = new OperationAggregate(operationController.GetAllOperationForTimePeriod(startDate, endDate));
                    var iteratorOperation = operations.CreateIterator();
                    if (operations.Count() > 0)
                    {
                        Console.WriteLine("\t***Operacije***");
                        while (iteratorOperation.IsDone())
                        {
                            if(iteratorOperation.CurrentItem().OperatingRoom.Id.Equals( room.Id))
                            {
                                Doctor doctor = doctorController.GetDoctorById(iteratorOperation.CurrentItem().Doctor.Pin);
                                RegisteredPatient registeredPatient = registeredPatientController.Get(iteratorOperation.CurrentItem().RegisteredPatient.Pin);
                                Console.WriteLine(doctor.Name + " "
                                    + doctor.Surname + " "
                                    + iteratorOperation.CurrentItem().Date.Date.ToString() + " "
                                    + registeredPatient.Name + " "
                                    + registeredPatient.Surname + " "
                                    + iteratorOperation.CurrentItem().Term.Start);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nema intervencija za uneti period");
                    }
                    Console.WriteLine("------------------------------------------------------------------");
                    return;
                }
            }

        }
        static void MakeDoctorReport()
        {
            DoctorController doctorController = new DoctorController(new DoctorService(new DoctorRepository()));
            DoctorAggregate doctors = new DoctorAggregate(doctorController.GetAllDoctors());
            var iterator = doctors.CreateIterator();
            Console.WriteLine("\t***IZVESTAJ O LEKARU***");
            Console.WriteLine("Odaberite Lekara:");
            int i = 1;
            while (iterator.IsDone()) Console.WriteLine(i++ + ". " + iterator.CurrentItem().Name + " " + iterator.CurrentItem().Surname);
            Console.WriteLine("0. Izlaz");
            int command = insertCommand();
            if (command == 0) return;
            Doctor doc = iterator.GetItem(command - 1);
            PrintAllDoctorIntervention(doc);
        }

        static void PrintAllDoctorIntervention(Doctor doctor)
        {
            ExaminationController examinationController = new ExaminationController(new ExaminationService(new ExaminationRepository(),new OperationRepository(), new DoctorRepository()));
            RegisteredPatientController registeredPatientController = new RegisteredPatientController(new RegisteredPatientService(new RegisteredPatientRepository(), new RegisteredUserRepository(), new PatientChartRepository()));
            OperationController operationController = new OperationController(new OperationService(new OperationRepository()));
            Console.WriteLine("Izvestaj za lekara " + doctor.Name + " " + doctor.Surname);
            string dateInterval;
            while (true)
            {
                Console.WriteLine("Unesite vremenski interval (dd/MM/yyyy-dd/MM/yyyy):");
                dateInterval = Console.ReadLine();
                if (!dateInterval.Contains("-") && (dateInterval.Length != 21))
                {
                    Console.WriteLine("Pogresan unos datuma pokusajte ponovo");
                }
                else
                {
                    string[] dates = dateInterval.Split('-');
                    string[] start = dates[0].Split('/');
                    string[] end = dates[1].Split('/');
                    DateTime startDate = new DateTime(int.Parse(start[2]), int.Parse(start[1]), int.Parse(start[0]), 0, 0, 0);
                    DateTime endDate = new DateTime(int.Parse(end[2]), int.Parse(end[1]), int.Parse(end[0]), 23, 59, 59);

                    ExamAggregate exams = new ExamAggregate(examinationController.GetAllDoctorsExamsForTimePeriod(doctor, startDate, endDate));
                    var iteratorExams = exams.CreateIterator();
                    if (exams.Count() > 0)
                    {

                        Console.WriteLine("\t***Pregledi***");
                        while (iteratorExams.IsDone())
                        {
                            RegisteredPatient registeredPatient = registeredPatientController.Get(iteratorExams.CurrentItem().RegisteredPatient.Pin);
                            Console.WriteLine(doctor.Name + " "
                                + doctor.Surname + " "
                                + iteratorExams.CurrentItem().Date.Date + " "
                                + registeredPatient.Name + " "
                                + registeredPatient.Surname + " "
                                + iteratorExams.CurrentItem().Term.Start);
                        }
                    }


                    OperationAggregate operations = new OperationAggregate(operationController.GetAllDoctorsOperationsForTimePeriod(doctor, startDate, endDate));
                    var iteratorOperation = operations.CreateIterator();
                    if (operations.Count() > 0)
                    {
                        Console.WriteLine("\t***Operacije***");
                        while (iteratorOperation.IsDone())
                        {
                            RegisteredPatient registeredPatient = registeredPatientController.Get(iteratorOperation.CurrentItem().RegisteredPatient.Pin);
                            Console.WriteLine(doctor.Name + " "
                                + doctor.Surname + " "
                                + iteratorOperation.CurrentItem().Date.Date + " "
                                + registeredPatient.Name + " "
                                + registeredPatient.Surname + " "
                                + iteratorOperation.CurrentItem().Term.Start);
                        }
                    }

                    if (operations.Count() < 1 && exams.Count() < 1)
                    {
                        Console.WriteLine("Nema intervencija za uneti period");
                    }

                    Console.WriteLine("------------------------------------------------------------------");
                    return;

                }
            }
        }

        static void MakeAppointment()
        {
            Console.WriteLine("\t***ZAKAZIVANJE I OTKAZIVANJE TERMINA***");

            while(true)
            {
                Console.WriteLine("1. Zakazivanje pregleda");
                Console.WriteLine("2. Otkazivanje pregleda");
                Console.WriteLine("0. Izlaz");
                int command = insertCommand();
                Console.WriteLine("------------------------------------------------------------------");
                if (command == 0) return;
                else if (command == 1) MakeNewAppointment();
                else if (command == 2) CancelAppointment();
            }
        }

        static void MakeNewAppointment()
        {
            Console.WriteLine("\t***ZAKAZIVANJE PREGLEDA***");
            Console.WriteLine("1. Pacijent je registrovan");
            Console.WriteLine("2. Pacijent nije registrovan");
            Console.WriteLine("3. Zahtevi za hitan pregled");
            Console.WriteLine("0. Izlaz");

            int command = insertCommand();
            Console.WriteLine("------------------------------------------------------------------");
            if (command == 0) return;
            else if (command == 1) MakeAppointmentForRegisteredPatient();
            else if (command == 2) MakeAppointmentForUnregisteredPatient();
            else if (command == 3) EmergencyExamSchedule();
        }

        static void EmergencyExamSchedule()
        {

            RegisteredPatientController registeredPatientController = new RegisteredPatientController(new RegisteredPatientService(new RegisteredPatientRepository(), new RegisteredUserRepository(), new PatientChartRepository()));
            DoctorController doctorController = new DoctorController(new DoctorService(new DoctorRepository()));
            NotificationController notificationController = new NotificationController(new NotificationService(new NotificationRepository()));
            AppointmentController appointmentController = new AppointmentController(new AppointmentService(new OperationRepository(), new ExaminationRepository(), new DoctorRepository()));
            ExaminationController examinationController = new ExaminationController(new ExaminationService(new ExaminationRepository(), new OperationRepository(), new DoctorRepository()));


            DateTime dt;
            Console.WriteLine("\t***ZAKAZIVANJE HITNOG PREGLEDA NA ZAHTEV***");

            List<Notification> notifications = notificationController.GetAllEmergencyExamsRequests();

            if(notifications.Count < 1)
            {
                Console.WriteLine("Nema zahteva za hitan pregled");
            }
            else
            {
                Console.WriteLine("Izaberite zahtev za hitan pregled");
                int i = 1;
                foreach (Notification notification in notifications)
                {
                    RegisteredPatient registeredPatient = registeredPatientController.Get(notification.RegisteredUser.Pin);
                    Console.WriteLine(i++ + ". " + notification.Id + " " + notification.DateOfCreation+ " " + registeredPatient.Name + " " + registeredPatient.Surname);
                }
                Console.WriteLine("0. Izlaz");
                int command = insertCommand();
                if (command == 0) return;
                while (command < 0 || command > notifications.Count())
                {
                    Console.WriteLine("Odaberite zahtev ponovo :");
                    Console.WriteLine("0. Izlaz");
                    command = insertCommand();
                    if (command == 0) return;
                }
                Notification notifi = notifications[command - 1];
                DoctorAggregate doctors = new DoctorAggregate(doctorController.GetAllDoctors());
                var iterator = doctors.CreateIterator();
                Console.WriteLine("Odaberite Lekara:");
                i = 1;
                while (iterator.IsDone()) Console.WriteLine(i++ + ". " + iterator.CurrentItem().Name + " " + iterator.CurrentItem().Surname);
                Console.WriteLine("0. Izlaz");
                command = insertCommand();
                if (command == 0) return;
                while (command < 0 || command > doctors.Count())
                {
                    Console.WriteLine("Odaberite Lekara ponovo :");
                    Console.WriteLine("0. Izlaz");
                    command = insertCommand();
                    if (command == 0) return;
                }
                Doctor doctor = iterator.GetItem(command - 1);
                Console.WriteLine("Unesite datum pregleda");
                string date = Console.ReadLine();

                while (!DateTime.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    Console.WriteLine("Pogresno unesen datum, probajte ponovo (dd/MM/yyyy)");
                    date = Console.ReadLine();
                }
                List<Term> freeTermsForDate = appointmentController.GetAllDoctorsFreeTermsForDate(doctor, dt);
                if (freeTermsForDate == null)
                {
                    Console.WriteLine("Za odabrani datum nema slobodnih termina");
                }
                else
                {
                    Term term = freeTermsForDate[0];
                    RandomStringGenerator randomId = new RandomStringGenerator(9);
                    while (examinationController.GetExamById(randomId.RandomString) != null)
                    {
                        randomId = new RandomStringGenerator(9);
                    }

                    Room examRoom = examRoomController.GetExamRoomById(doctor.DefaultExamRoom.Id);

                    Examination examination = new Examination(examRoom, false, randomId.RandomString, AppointmentType.EXAMINATION, new RegisteredPatient(notifi.RegisteredUser.Pin), term, doctor, dt);
                    examinationController.ScheduleExam(examination);
                    notifi.IsEmergencyAppointment = NotificationType.EMERGENCY_RESPONSE;
                    notifi.Text = "Vas pregled je zakazan "+examination.Term.Start;
                    notificationController.ResponseToEmergencyRequest(notifi);
                    Console.WriteLine("Pregled uspesno zakazan(notifikacija poslata)");

                }
            }

        }

        static void MakeAppointmentForUnregisteredPatient()
        {
            RegisteredPatientController registeredPatientController = new RegisteredPatientController(new RegisteredPatientService(new RegisteredPatientRepository(), new RegisteredUserRepository(), new PatientChartRepository()));
            DoctorController doctorController = new DoctorController(new DoctorService(new DoctorRepository()));
            AppointmentController appointmentController = new AppointmentController(new AppointmentService(new OperationRepository(), new ExaminationRepository(), new DoctorRepository()));
            ExaminationController examinationController = new ExaminationController(new ExaminationService(new ExaminationRepository(), new OperationRepository(), new DoctorRepository()));
            ExamRoomController examRoomController = new ExamRoomController(new ExamRoomService(new ExamRoomRepository()));
            UserController userController = new UserController(new UserService(new RegisteredUserRepository(), new BlogArticlesRepository(), new QuestionsRepository(), new PersonRepository()));
            Console.WriteLine("Pacijent je vec bio u klinici(y/n)");
            string personExist;
            personExist = Console.ReadLine();
            Person person;
            if (personExist.Trim().Equals("y") || personExist.Trim().Equals("Y"))
            {
                Console.WriteLine("Unesite pin pacijenta:");
                string personPin = Console.ReadLine();
                 person = userController.GetKnownPerson(personPin);
                if (person == null)
                {
                    Console.WriteLine("Nema trazenog pacijenta u evidenciji");
                    return;
                }
            }
            else
            {
                person = IntroduceYourself();
                userController.AddKnownPerson(person);
            }
            DateTime dt;
            DoctorAggregate doctors = new DoctorAggregate(doctorController.GetAllDoctors());
            var iterator = doctors.CreateIterator();
            Console.WriteLine("Odaberite Lekara:");
            int i = 1;
            while (iterator.IsDone()) Console.WriteLine(i++ + ". " + iterator.CurrentItem().Name + " " + iterator.CurrentItem().Surname);
            Console.WriteLine("0. Izlaz");
            int command = insertCommand();
            if (command == 0) return;
            while (command < 0 || command > doctors.Count())
            {
                Console.WriteLine("Odaberite Lekara ponovo :");
                Console.WriteLine("0. Izlaz");
                command = insertCommand();
                if (command == 0) return;
            }
            Doctor doctor = iterator.GetItem(command - 1);
            Console.WriteLine("Unesite datum pregleda");
            string date = Console.ReadLine();

            while (!DateTime.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Pogresno unesen datum, probajte ponovo (dd/MM/yyyy)");
                date = Console.ReadLine();
            }
            List<Term> freeTermsForDate = appointmentController.GetAllDoctorsFreeTermsForDate(doctor, dt);
            if (freeTermsForDate == null)
            {
                Console.WriteLine("Za odabrani datum nema slobodnih termina");
            }
            else
            {
                Dictionary<int, Term> termsDict = new Dictionary<int, Term>();

                for (int counter = 0; counter < freeTermsForDate.Count; counter++)
                {
                    Console.WriteLine(counter + " - " + freeTermsForDate[counter].Start);
                    Console.WriteLine("----");
                    termsDict.Add(counter, freeTermsForDate[counter]);
                }
                int input;
                while (true)
                {
                    try
                    {
                        input = int.Parse(Console.ReadLine());
                        if (input >= 0 && input < freeTermsForDate.Count)
                            break;
                        else
                            Console.WriteLine("Unesite odgovarajuci broj");
                    }
                    catch
                    {
                        Console.WriteLine("Nije dobar unos, pokusajte ponovo");
                    }
                }

                Term examTerm = termsDict[input];

                RandomStringGenerator randomId = new RandomStringGenerator(9);
                while (examinationController.GetExamById(randomId.RandomString) != null)
                {
                    randomId = new RandomStringGenerator(9);
                }

                Room examRoom = examRoomController.GetExamRoomById(doctor.DefaultExamRoom.Id);

                Examination examination = new Examination(examRoom, false, randomId.RandomString, AppointmentType.EXAMINATION, new RegisteredPatient(person.Pin), examTerm, doctor, dt);
                examinationController.ScheduleExam(examination);

                Console.WriteLine("Pregled uspesno zakazan");
            }
        }
        static void MakeAppointmentForRegisteredPatient()
        {
            RegisteredPatientController registeredPatientController = new RegisteredPatientController(new RegisteredPatientService(new RegisteredPatientRepository(), new RegisteredUserRepository(), new PatientChartRepository()));
            DoctorController doctorController = new DoctorController(new DoctorService(new DoctorRepository()));
            AppointmentController appointmentController = new AppointmentController(new AppointmentService(new OperationRepository(), new ExaminationRepository(), new DoctorRepository()));
            ExaminationController examinationController = new ExaminationController(new ExaminationService(new ExaminationRepository(), new OperationRepository(), new DoctorRepository()));
            Console.WriteLine("Unesite jmbg pacijenta:");
            string pin = Console.ReadLine();
            DateTime dt;
            RegisteredPatient registeredPatient = registeredPatientController.Get(pin);

            if(registeredPatient != null)
            {
                DoctorAggregate doctors = new DoctorAggregate(doctorController.GetAllDoctors());
                var iterator = doctors.CreateIterator();
                Console.WriteLine("Odaberite Lekara:");
                int i = 1;
                while (iterator.IsDone()) Console.WriteLine(i++ + ". " + iterator.CurrentItem().Name + " " + iterator.CurrentItem().Surname);
                Console.WriteLine("0. Izlaz");
                int command = insertCommand();
                if (command == 0) return;
                while (command < 0 || command > doctors.Count())
                {
                    Console.WriteLine("Odaberite Lekara ponovo :");
                    Console.WriteLine("0. Izlaz");
                    command = insertCommand();
                    if (command == 0) return;
                }
                Doctor doctor = iterator.GetItem(command - 1);
                Console.WriteLine("Unesite datum za pregled");
                string date = Console.ReadLine();
                
                while (!DateTime.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    Console.WriteLine("Pogresno unesen datum, probajte ponovo (dd/MM/yyyy)");
                    date = Console.ReadLine();
                }
                List<Term> freeTermsForDate = appointmentController.GetAllDoctorsFreeTermsForDate(doctor, dt);
                if (freeTermsForDate == null)
                {
                    Console.WriteLine("Za odabrani datum nema slobodnih termina");
                }
                else
                {
                    Dictionary<int, Term> termsDict = new Dictionary<int, Term>();

                    for (int counter = 0; counter < freeTermsForDate.Count; counter++)
                    {
                        Console.WriteLine(counter + " - " + freeTermsForDate[counter].Start);
                        Console.WriteLine("----");
                        termsDict.Add(counter, freeTermsForDate[counter]);
                    }
                    int input;
                    while (true)
                    {
                        try
                        {
                            input = int.Parse(Console.ReadLine());
                            if (input >= 0 && input < freeTermsForDate.Count)
                                break;
                            else
                                Console.WriteLine("Unesite odgovarajuci broj");
                        }
                        catch
                        {
                            Console.WriteLine("Nije dobar unos, pokusajte ponovo");
                        }
                    }

                    Term examTerm = termsDict[input];

                    RandomStringGenerator randomId = new RandomStringGenerator(9);
                    while (examinationController.GetExamById(randomId.RandomString) != null)
                    {
                        randomId = new RandomStringGenerator(9);
                    }

                    Room examRoom = examRoomController.GetExamRoomById(doctor.DefaultExamRoom.Id);

                    Examination examination = new Examination(examRoom, false, randomId.RandomString, AppointmentType.EXAMINATION, new RegisteredPatient(registeredPatient.Pin), examTerm, doctor, dt);
                    examinationController.ScheduleExam(examination);
                    Console.WriteLine("Pregled uspesno zakazan");
                }
            }
            else
            {
                Console.WriteLine("Pacijent ne postoji u evidenciji");
            }
        }

        static void CancelAppointment()
        {
            NotificationController notificationController = new NotificationController(new NotificationService(new NotificationRepository()));
            RegisteredPatientController registeredPatientController = new RegisteredPatientController(new RegisteredPatientService(new RegisteredPatientRepository(), new RegisteredUserRepository(), new PatientChartRepository()));
            UserController userController = new UserController(new UserService(new RegisteredUserRepository(), new BlogArticlesRepository(), new QuestionsRepository(), new PersonRepository()));
            AppointmentController appointmentController = new AppointmentController(new AppointmentService(new OperationRepository(), new ExaminationRepository(), new DoctorRepository()));
            ExaminationController examinationController = new ExaminationController(new ExaminationService(new ExaminationRepository(), new OperationRepository(), new DoctorRepository()));
            OperationController operationController = new OperationController(new OperationService(new OperationRepository()));
            DoctorController doctorController = new DoctorController(new Service.ServiceDoctor.DoctorService(new DoctorRepository()));

            Console.WriteLine("\t***OTKAZIVANJE PREGLEDA***");
            Console.WriteLine("Odaberite termin za otkazivanje");
            List<Appointment> appointments = appointmentController.GetAllAppointments();
            int i = 1;
            foreach (Appointment app in appointments)
            {
                Doctor doc = doctorController.GetDoctorById(app.Doctor.Pin);
                RegisteredPatient registeredPatient = registeredPatientController.Get(app.RegisteredPatient.Pin);
                Person person = null;
                if (registeredPatient == null)
                    person = userController.GetKnownPerson(app.RegisteredPatient.Pin);

                Console.WriteLine(i++ + ". " + app.Id + " " + app.Term.Start + " " + doc.Name + " " + doc.Surname + " " + (registeredPatient == null ? (person.Name + " " + person.Surname) : (registeredPatient.Name + " " + registeredPatient.Surname)) + " " + app.Type);
            }
            Console.WriteLine("0. Izlaz");
            int command = insertCommand();
            if (command == 0) return;
            while (command < 0 || command > appointments.Count())
            {
                Console.WriteLine("Odaberite termin ponovo :");
                Console.WriteLine("0. Izlaz");
                command = insertCommand();
                if (command == 0) return;
            }
            RandomStringGenerator randomId = new RandomStringGenerator(9);
            while (notificationController.GetNotification(randomId.RandomString) != null)
            {
                randomId = new RandomStringGenerator(9);
            }
            Appointment appointment = appointments[command - 1];
            if (appointment.Type.Equals(AppointmentType.OPERATION))
            {

                operationController.CancelOperation(appointment.Id);
                notificationController.NewNotification(new Notification(appointment.RegisteredPatient.Pin,randomId.ToString(),"Vasa operacija u terminu "+appointment.Term.Start+"je otkazana. Molimo vas kontaktirajte kliniku radi daljih informacija", DateTime.Now, NotificationType.RESCHEDULE));
                Console.WriteLine("Operacija uspesno otkazana(notifikacija poslata)");
            }
            else
            {
                examinationController.CancelExam(appointment.Id);
                notificationController.NewNotification(new Notification(appointment.RegisteredPatient.Pin, randomId.ToString(), "Vas pregled u terminu " + appointment.Term.Start + "je otkazan. Molimo vas kontaktirajte kliniku radi daljih informacija", DateTime.Now, NotificationType.RESCHEDULE));
                Console.WriteLine("Pregled uspesno otkazan(notifikacija poslata)");
            }
          
        }

        static void ChooseSecretaryAction()
        {
            int command = 0;
            bool logout = false;
            while (!logout)
            {
                Console.WriteLine("\t***Odaberite opciju***");
                Console.WriteLine("1. Kreiraj nalog pacijentu");
                Console.WriteLine("2. Napravi izvestaj");
                Console.WriteLine("3. Zakazi/otkazi termin");
                Console.WriteLine("4. Promeni lozinku");
                Console.WriteLine("0. Izlaz");
                command = insertCommand();
                Console.WriteLine("------------------------------------------------------------------");
                switch (command)
                {
                    case 1:
                        CreatePatientAccount();
                        break;
                    case 2:
                        CreateSecretaryReport();
                        break;
                    case 3:
                        MakeAppointment();
                        break;
                    case 4:
                        ChangePatientPassword();
                        break;
                    case 0:
                        logout = true;
                        break;
                }

            }
        }
        static void SecretaryLogIn()
        {
            City city = new City("Kekenda", 21000);
            State state = new State("Vodzvodina");
            Address address = new Address("Legijina", 1);
            Location location = new Location(state, city, address);
            
            SecretaryController secretaryController = new SecretaryController(new SecretaryService(new SecretaryRepository(), new NotificationRepository()));
            string username = "";
            string password = "";
            bool isValidUsernameAndPassword = false;
            while (!isValidUsernameAndPassword)
            {
                Console.WriteLine("0. Izlaz");
                Console.WriteLine("Unesite korisnicko ime:");
                username = Console.ReadLine();
                if (CheckForExit(username)) return;
                Console.WriteLine("Unesite lozinku:");
                password = Console.ReadLine();
                if (CheckForExit(password)) return;
                if (isValidUsernameAndPassword = secretaryController.DoesSecretaryExist(username.Trim(), password.Trim()))
                {
                    Console.WriteLine("------------------------------------------------------------------");
                    ChooseSecretaryAction();

                }
                else
                {
                    Console.WriteLine("Pogresno korisnicko ime ili lozinka:");
                }

            }
        }
        static int insertCommand()
        {
            int result = 0;
            while (!Int32.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Unos mora biti ceo broj!");
            }
            return result;
        }

        static bool CheckForExit(string st)
        {
            int result;
            bool isNum = Int32.TryParse(st.Trim(), out result);
            if (isNum && result == 0) return true;
            return false;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool Running = true;
            while(Running)
            {
                int Option = Menu();
                switch(Option)
                {
                    case 1:
                        {
                            Debug();
                        }break;
                    case 2:
                        {
                            DeanOptions();
                        }break;
                    case 3:
                        {
                            DoctorOptions();
                        }
                        break;
                    case 4:
                        {
                            PatientConsole patientOptions = new PatientConsole();
                            break;
                        }
                    case 5:
                        {
                            SecretaryLogIn();
                            break;
                        }
                    case 0:
                    default:
                        {
                            Running = false;
                        }break;
                }
            }
            


        }
    }
}
