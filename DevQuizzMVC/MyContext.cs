using DevQuizzMVC.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace DevQuizzMVC
{
    public class MyContext : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « MyContext » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « DevQuizzMVC.MyContext » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « MyContext » dans le fichier de configuration de l'application.
        public MyContext()
            : base("name=MyContext")
        {
        }

        

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Quizz> Quizzes { get; set; }

        public virtual DbSet<QuestionQuizz> QuestionQuizzes { get; set; }
        public virtual DbSet<AnswerQuizz> AnswerQuizzes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionQuizz>()
                .HasRequired(q => q.Quizz)
                .WithMany(qst => qst.QuestionsQuizz)
                .HasForeignKey(q => q.QuizzId)
                .WillCascadeOnDelete(true);


            modelBuilder.Entity<AnswerQuizz>()
                .HasRequired(q => q.QuestionQuizz)
                .WithMany(a => a.AnswersQuizz)
                .HasForeignKey(q => q.QuestionQuizzId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Quizz>()
                .HasRequired(q => q.QuizzCategory)
                .WithMany(a => a.Quizzs)
                .HasForeignKey(q => q.CategoryId)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }

        
    }



    
}