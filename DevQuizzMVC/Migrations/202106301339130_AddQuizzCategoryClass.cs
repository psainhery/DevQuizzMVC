namespace DevQuizzMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuizzCategoryClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuizzCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Quizzs", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Quizzs", "CategoryId");
            AddForeignKey("dbo.Quizzs", "CategoryId", "dbo.QuizzCategories", "Id");
            DropColumn("dbo.Quizzs", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quizzs", "Category", c => c.String());
            DropForeignKey("dbo.Quizzs", "CategoryId", "dbo.QuizzCategories");
            DropIndex("dbo.Quizzs", new[] { "CategoryId" });
            DropColumn("dbo.Quizzs", "CategoryId");
            DropTable("dbo.QuizzCategories");
        }
    }
}
