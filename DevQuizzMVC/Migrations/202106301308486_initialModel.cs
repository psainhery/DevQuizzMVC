namespace DevQuizzMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerQuizzs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnswerText = c.String(),
                        isCorrect = c.Boolean(nullable: false),
                        QuestionQuizzId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionQuizzs", t => t.QuestionQuizzId)
                .Index(t => t.QuestionQuizzId);
            
            CreateTable(
                "dbo.QuestionQuizzs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(),
                        isMultiple = c.Boolean(nullable: false),
                        QuizzId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizzs", t => t.QuizzId)
                .Index(t => t.QuizzId);
            
            CreateTable(
                "dbo.Quizzs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
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
            DropForeignKey("dbo.AnswerQuizzs", "QuestionQuizzId", "dbo.QuestionQuizzs");
            DropForeignKey("dbo.QuestionQuizzs", "QuizzId", "dbo.Quizzs");
            DropIndex("dbo.QuestionQuizzs", new[] { "QuizzId" });
            DropIndex("dbo.AnswerQuizzs", new[] { "QuestionQuizzId" });
            DropTable("dbo.Users");
            DropTable("dbo.Quizzs");
            DropTable("dbo.QuestionQuizzs");
            DropTable("dbo.AnswerQuizz");
        }
    }
}
