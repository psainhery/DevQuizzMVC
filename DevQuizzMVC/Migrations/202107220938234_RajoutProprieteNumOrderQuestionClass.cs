namespace DevQuizzMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RajoutProprieteNumOrderQuestionClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuestionQuizzs", "NumOrder", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuestionQuizzs", "NumOrder");
        }
    }
}
