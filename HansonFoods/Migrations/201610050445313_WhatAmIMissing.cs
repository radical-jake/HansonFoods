namespace HansonFoods.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WhatAmIMissing : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FoodItems", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.FoodItems", "Url", c => c.String(maxLength: 256));
            AlterColumn("dbo.FoodItems", "Email", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FoodItems", "Email", c => c.String());
            AlterColumn("dbo.FoodItems", "Url", c => c.String());
            AlterColumn("dbo.FoodItems", "Name", c => c.String());
        }
    }
}
