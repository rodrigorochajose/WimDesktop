namespace DMMDigital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CLINIC",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NAME = c.String(nullable: false, maxLength: 130),
                        EMAIL = c.String(nullable: false, maxLength: 130),
                        PASSWORD = c.String(nullable: false),
                        CREATED_AT = c.DateTime(nullable: false),
                        KEEP_CONNECTED = c.Int(nullable: false),
                        AUTOMATIC_LOGIN = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.SENSOR",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    NAME = c.String(),
                    NICKNAME = c.String(),
                    WIDTH = c.Single(nullable: false),
                    HEIGHT = c.Single(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.SETTINGS",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    LANGUAGE = c.String(),
                    SENSOR_PATH = c.String(),
                    EXAM_PATH = c.String(),
                    EXPORT_PATH = c.String(),
                    SENSOR_MODEL = c.String(),
                    ACQUIRE_MODE = c.Int(nullable: false),
                    DRAWING_COLOR = c.String(),
                    DRAWING_SIZE = c.Int(nullable: false),
                    TEXT_COLOR = c.String(),
                    TEXT_SIZE = c.Int(nullable: false),
                    RULER_COLOR = c.String(),
                    FILTER_BRIGHTNESS = c.Single(nullable: false),
                    FILTER_CONTRAST = c.Single(nullable: false),
                    FILTER_REVEAL = c.Single(nullable: false),
                    FILTER_SMART_SHARPEN = c.Single(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.TEMPLATE",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    NAME = c.String(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.TEMPLATE_FRAME",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    TEMPLATE_ID = c.Int(nullable: false),
                    ORDINATION = c.Int(nullable: false),
                    LOCATION_X = c.Int(nullable: false),
                    LOCATION_Y = c.Int(nullable: false),
                    ORIENTATION = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TEMPLATE", t => t.TEMPLATE_ID, cascadeDelete: true, name: "FK_TF_T_ID");

            CreateTable(
                "dbo.PATIENT",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    NAME = c.String(nullable: false, maxLength: 130),
                    BIRTH_DATE = c.DateTime(nullable: false),
                    PHONE = c.String(),
                    RECOMMENDATION = c.String(),
                    OBSERVATION = c.String(),
                    CREATED_AT = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.EXAM",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PATIENT_ID = c.Int(nullable: false),
                        TEMPLATE_ID = c.Int(nullable: false),
                        SESSION_NAME = c.String(),
                        CREATED_AT = c.DateTime(nullable: false),
                        UPDATED_AT = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PATIENT", t => t.PATIENT_ID, cascadeDelete: true, name: "FK_E_P_ID")
                .ForeignKey("dbo.TEMPLATE", t => t.TEMPLATE_ID, cascadeDelete: true, name: "FK_E_T_ID")
                .Index(t => t.PATIENT_ID)
                .Index(t => t.TEMPLATE_ID);
            
            CreateTable(
                "dbo.EXAM_IMAGE",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EXAM_ID = c.Int(nullable: false),
                        TEMPLATE_FRAME_ID = c.Int(nullable: false),
                        FILE = c.String(),
                        NOTES = c.String(),
                        CREATED_AT = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EXAM", t => t.EXAM_ID, cascadeDelete: true, name: "FK_EI_E_ID")
                .ForeignKey("dbo.TEMPLATE_FRAME", t => t.TEMPLATE_FRAME_ID, cascadeDelete: true, name: "FK_EI_TF_ID")
                .Index(t => t.EXAM_ID);
            
            CreateTable(
                "dbo.EXAM_IMAGE_DRAWING",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EXAM_ID = c.Int(nullable: false),
                        EXAM_IMAGE_ID = c.Int(nullable: false),
                        DRAWING_COLOR = c.String(),
                        DRAWING_SIZE = c.Int(nullable: false),
                        DRAWING_TYPE = c.String(),
                        DRAWING_TEXT = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EXAM", t => t.EXAM_ID, cascadeDelete: true, name: "FK_EID_E_ID")
                .ForeignKey("dbo.EXAM_IMAGE", t => t.EXAM_IMAGE_ID, cascadeDelete: true, name: "FK_EID_EI_ID");

            CreateTable(
                "dbo.EXAM_IMAGE_DRAWING_POINTS",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EXAM_IMAGE_DRAWING_ID = c.Int(nullable: false),
                        POINT_X = c.Int(nullable: false),
                        POINT_Y = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EXAM_IMAGE_DRAWING", t => t.EXAM_IMAGE_DRAWING_ID, cascadeDelete: true, name: "FK_EIDP_EID_ID");

            CreateTable(
                "dbo.RULER_LENGTH",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EXAM_IMAGE_DRAWING_ID = c.Int(nullable: false),
                        LINE_LENGTH = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EXAM_IMAGE_DRAWING", t => t.EXAM_IMAGE_DRAWING_ID, cascadeDelete: true, name: "FK_RL_EID_ID");

            CreateTable(
                "dbo.HistoryRows",
                c => new
                    {
                        MigrationId = c.String(nullable: false, maxLength: 100),
                        ContextKey = c.String(nullable: false, maxLength: 100),
                        Model = c.Binary(),
                        ProductVersion = c.String(),
                    })
                .PrimaryKey(t => new { t.MigrationId, t.ContextKey });
        }

        public override void Down()
        {
            DropForeignKey("dbo.EXAM", "TEMPLATE_ID", "dbo.TEMPLATE");
            DropForeignKey("dbo.EXAM", "PATIENT_ID", "dbo.PATIENT");
            DropForeignKey("dbo.EXAM_IMAGE", "EXAM_ID", "dbo.EXAM");
            DropIndex("dbo.EXAM_IMAGE", new[] { "EXAM_ID" });
            DropIndex("dbo.EXAM", new[] { "TEMPLATE_ID" });
            DropIndex("dbo.EXAM", new[] { "PATIENT_ID" });
            DropTable("dbo.HistoryRows");
            DropTable("dbo.TEMPLATE_FRAME");
            DropTable("dbo.SETTINGS");
            DropTable("dbo.SENSOR");
            DropTable("dbo.RULER_LENGTH");
            DropTable("dbo.EXAM_IMAGE_DRAWING_POINTS");
            DropTable("dbo.EXAM_IMAGE_DRAWING");
            DropTable("dbo.TEMPLATE");
            DropTable("dbo.PATIENT");
            DropTable("dbo.EXAM_IMAGE");
            DropTable("dbo.EXAM");
            DropTable("dbo.CLINIC");
        }
    }
}
