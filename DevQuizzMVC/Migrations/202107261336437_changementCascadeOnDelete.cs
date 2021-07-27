namespace DevQuizzMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changementCascadeOnDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AnswerQuizzs", "QuestionQuizzId", "dbo.QuestionQuizzs");
            DropForeignKey("dbo.QuestionQuizzs", "QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.Quizzs", "CategoryId", "dbo.QuizzCategories");
            AddForeignKey("dbo.AnswerQuizzs", "QuestionQuizzId", "dbo.QuestionQuizzs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.QuestionQuizzs", "QuizzId", "dbo.Quizzs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Quizzs", "CategoryId", "dbo.QuizzCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quizzs", "CategoryId", "dbo.QuizzCategories");
            DropForeignKey("dbo.QuestionQuizzs", "QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.AnswerQuizzs", "QuestionQuizzId", "dbo.QuestionQuizzs");
            AddForeignKey("dbo.Quizzs", "CategoryId", "dbo.QuizzCategories", "Id");
            AddForeignKey("dbo.QuestionQuizzs", "QuizzId", "dbo.Quizzs", "Id");
            AddForeignKey("dbo.AnswerQuizzs", "QuestionQuizzId", "dbo.QuestionQuizzs", "Id");
        }
    }
}
