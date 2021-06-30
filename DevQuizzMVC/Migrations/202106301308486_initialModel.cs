namespace DevQuizzMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerQuizz",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnswerText = c.String(),
                        isCorrect = c.Boolean(nullable: false),
                        QuestionQuizzId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionQuizz", t => t.QuestionQuizzId)
                .Index(t => t.QuestionQuizzId);
            
            CreateTable(
                "dbo.QuestionQuizz",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(),
                        isMultiple = c.Boolean(nullable: false),
                        QuizzId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizz", t => t.QuizzId)
                .Index(t => t.QuizzId);
            
            CreateTable(
                "dbo.Quizz",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        isAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnswerQuizz", "QuestionQuizzId", "dbo.QuestionQuizz");
            DropForeignKey("dbo.QuestionQuizz", "QuizzId", "dbo.Quizz");
            DropIndex("dbo.QuestionQuizz", new[] { "QuizzId" });
            DropIndex("dbo.AnswerQuizz", new[] { "QuestionQuizzId" });
            DropTable("dbo.User");
            DropTable("dbo.Quizz");
            DropTable("dbo.QuestionQuizz");
            DropTable("dbo.AnswerQuizz");
        }
    }
}
