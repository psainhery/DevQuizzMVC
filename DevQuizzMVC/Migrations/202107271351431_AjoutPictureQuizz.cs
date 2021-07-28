namespace DevQuizzMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutPictureQuizz : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quizzs", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quizzs", "Picture");
        }
    }
}
