namespace HansonFoods.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingToEnumForRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FoodItems", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FoodItems", "Rating");
        }
    }
}
