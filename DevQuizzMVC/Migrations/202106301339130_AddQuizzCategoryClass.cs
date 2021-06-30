namespace DevQuizzMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuizzCategoryClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuizzCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Quizz", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Quizz", "CategoryId");
            AddForeignKey("dbo.Quizz", "CategoryId", "dbo.QuizzCategory", "Id");
            DropColumn("dbo.Quizz", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quizz", "Category", c => c.String());
            DropForeignKey("dbo.Quizz", "CategoryId", "dbo.QuizzCategory");
            DropIndex("dbo.Quizz", new[] { "CategoryId" });
            DropColumn("dbo.Quizz", "CategoryId");
            DropTable("dbo.QuizzCategory");
        }
    }
}
