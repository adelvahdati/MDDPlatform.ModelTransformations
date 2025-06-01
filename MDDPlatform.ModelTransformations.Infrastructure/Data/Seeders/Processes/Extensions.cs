using MDDPlatform.ModelTransformations.Core.Entities;
using MDDPlatform.ModelTransformations.Infrastructure.Data.Seeders.PatternTemplates;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Seeders.Processes;

public static class Extensions
{

    internal static Process AddInitialPhase(this Process process)
    {
        var phase = Phase.Create("Initial Phase");
        
        var activity = Activity.Create("Explore Problem Domain");
        activity.CreateTask(WorkUnit.CreateManualTask("Manage CRAC Workshop"));
        activity.CreateTask(WorkUnit.CreateManualTask("Create CRAC Models"));

        phase.CreateActivity(activity);

        process.AddPhase(phase);

        return process;
    }
    internal static Process AddCIMConstructionPhase(this Process process,IPatternInstanceTemplateRgistry templateRegistry)
    {
        var phase = Phase.Create("CIM Models Construction");

        var activity = Activity.Create("CIM to CIM Model Transformation");
        activity.CreateTask(WorkUnit.CreateModelTransformationTask("Map 'DomainConcept' of CRAC Model to 'DomainConcept' of CIM Model",templateRegistry.Map_CRAC_Concept_To_CIM_Model()));
        activity.CreateTask(WorkUnit.CreateModelTransformationTask("Map 'DomainConcept' Responsibilities to 'DomainConcept' Operations",templateRegistry.Convert_CRAC_Responsibility_To_Domain_Concept_Operation()));
        activity.CreateTask(WorkUnit.CreateManualTask("Describe 'DomainConcept' Properties in the CIM Model"));
        activity.CreateTask(WorkUnit.CreateModelTransformationTask("Convert Relation with Primitive ValueObject to the Concept Property",templateRegistry.Replace_CIM_model_Relation_with_Property()));
        activity.CreateTask(WorkUnit.CreateModelTransformationTask("Convert Association with Complex Type to the Concept Relation",templateRegistry.Replace_Associations_With_Relation()));

        phase.CreateActivity(activity);
        process.AddPhase(phase);
        return process;
 
    }
    internal static Process AddPIMConstructionPhase(this Process process,IPatternInstanceTemplateRgistry templateRegistry){
        var phase = Phase.Create("PIM Models Construction");

        var transformCIMtoPIMActivity = Activity.Create("Transform CIM Models to PIM Models");
        transformCIMtoPIMActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Convert CRAC Model to CQRS Model from 'CommandHandler' Perspective",templateRegistry.Convert_CRAC_model_to_CQRS_CommandHandler()));
        transformCIMtoPIMActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Convert CRAC Model to CQRS Model from 'EventHandler' Perspective",templateRegistry.Convert_CRAC_model_to_CQRS_EventHandler()));
        transformCIMtoPIMActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map 'DomainConcept' Responsibility to the 'Command' Dispatched By 'ApiController'",templateRegistry.Map_DomainConcept_Responsibility_to_the_command_dispatch_by_controller()));
        transformCIMtoPIMActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map CIM DomainConcept to PIM Entities",templateRegistry.Map_CIM_Domain_Concept_to_PIM_Entities()));
        phase.CreateActivity(transformCIMtoPIMActivity);

        var refineCQRSModelActivity = Activity.Create("Refine CQRS Model at the PIM Level of Abstraction");
        refineCQRSModelActivity.CreateTask(WorkUnit.CreateManualTask("Define Properties of Commands & Events in the CQRS Model"));
        refineCQRSModelActivity.CreateTask(WorkUnit.CreateManualTask("Define 'CommandHandler' & 'EventHandler' Collaborators"));
        refineCQRSModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Replace Relation With Property in the CQRS Model from 'Event' Perspective",templateRegistry.Replace_CQRS_Event_Relation_with_Property()));
        refineCQRSModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Replace Relation With Property in the CQRS Model from 'Command' Perspective",templateRegistry.Replace_CQRS_Command_Relation_with_Property()));
        refineCQRSModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Create 'Handle' Method of 'CommandHandler' in the CQRS Model",templateRegistry.Create_handle_method_of_command_handler_In_CQRS_Model()));
        refineCQRSModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Create 'Handle' Method of 'EventHandler' in the CQRS Model",templateRegistry.Create_handle_method_of_Event_handler_In_CQRS_Model()));
        refineCQRSModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Create 'CommandHandler' Constructor int the CQRS Model",templateRegistry.Create_command_handler_constructor_In_CQRS_Model()));
        refineCQRSModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Create 'EventHandler' Constructor int the CQRS Model",templateRegistry.Create_Event_handler_constructor_In_CQRS_Model()));
        // TODO : Convert Interface,Service & Repository DomainObjects of CQRS Model to DomainConcept
        phase.CreateActivity(refineCQRSModelActivity);

        var refineControllerModelActivity = Activity.Create("Refine ApiController Model at the PIM Level of Asbtraction");
        refineControllerModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Convert Dispatched 'Command' to the 'ApiController' Endpoint",templateRegistry.Convert_Dispatched_Command_to_the_Controller_Endpoint()));
        refineControllerModelActivity.CreateTask(WorkUnit.CreateManualTask("Set the Values of the Endpoint Properties"));
        refineControllerModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Convert 'ApiController' Endpoints to the Operations & Operation Attributes",templateRegistry.Convert_Controller_Endpoint_to_the_Operation_and_Attributes()));
        // TODO : Convert Interface & Service DomainObjects of Controller Model to DomainConcept
        phase.CreateActivity(refineControllerModelActivity);

        var mergeCoreDomainEntitiesActivity = Activity.Create("Merge PIM & CIM Core Domain Entities");
        mergeCoreDomainEntitiesActivity.CreateTask(WorkUnit.CreateManualTask("Describe Design-Specific Concerns of Core Domain"));
        mergeCoreDomainEntitiesActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Set Relational Dimension Between PIM & CIM Model",templateRegistry.Set_relationalDimension_Between_PIM_Entities_and_CIM_Domain_Concept()));
        mergeCoreDomainEntitiesActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Merge CIM Concepts With PIM Core Domain",templateRegistry.Merge_CIM_Concepts_With_PIM_Core_Domain()));
        phase.CreateActivity(mergeCoreDomainEntitiesActivity);

        process.AddPhase(phase);

        return process;
    }

    internal static Process AddPSMConstructionPhase(this Process process,IPatternInstanceTemplateRgistry templateRegistry)
    {
        var phase = Phase.Create("PSM Models Construction");

        var transformPIMToPSMActivity = Activity.Create("Transform PIM Models to PSM Models");
        transformPIMToPSMActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map PIM Controller Model to PSM Controller Model From 'ApiController' Perspective",templateRegistry.Map_PIM_Controller_to_PSM_Controller()));
        transformPIMToPSMActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map PIM Controller Model to PSM Controller Model From 'Interface' Perspective",templateRegistry.Map_PIM_Interfaces_to_PSM_Interfaces()));
        transformPIMToPSMActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map PIM Controller Model to PSM Controller Model From 'Service' Perspective",templateRegistry.Map_PIM_Services_to_PSM_Services()));

        transformPIMToPSMActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map PIM CQRS Model to PSM CQRS Model From 'Command' Perspective",templateRegistry.Map_PIM_CQRS_to_PSM_CQRS_Commands()));
        transformPIMToPSMActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map PIM CQRS Model to PSM CQRS Model From 'CommandHandler' Perspective",templateRegistry.Map_PIM_CQRS_to_PSM_CQRS_CommandHandler()));
        transformPIMToPSMActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map PIM CQRS Model to PSM CQRS Model From 'Event' Perspective",templateRegistry.Map_PIM_CQRS_to_PSM_CQRS_Event()));
        transformPIMToPSMActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map PIM CQRS Model to PSM CQRS Model From 'EventHandler' Perspective",templateRegistry.Map_PIM_CQRS_to_PSM_CQRS_EventHandler()));
        transformPIMToPSMActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map PIM CQRS Model to PSM CQRS Model From 'Interface' Perspective",templateRegistry.Map_PIM_Interfaces_to_PSM_Interfaces()));
        transformPIMToPSMActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map PIM CQRS Model to PSM CQRS Model From 'Service' Perspective",templateRegistry.Map_PIM_Services_to_PSM_Services()));
        transformPIMToPSMActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map PIM CQRS Model to PSM CQRS Model From 'Repository' Perspective",templateRegistry.Map_PIM_Repositories_to_PSM_Repositories()));

        transformPIMToPSMActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map PIM Core Domain Model to PSM Core Domain Model",templateRegistry.Map_PIM_Core_Domain_to_PSM_Core_Domain()));        
        phase.CreateActivity(transformPIMToPSMActivity);

        var refineMergeControllerActivity = Activity.Create("Refine PSM Controller Model and Merge with PIM Controller Model");
        refineMergeControllerActivity.CreateTask(WorkUnit.CreateManualTask("Describe Implementation-Specific Concerns of Controllers"));
        refineMergeControllerActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Set Relational Dimension Between PSM & PIM Controller Models",templateRegistry.Set_Relational_Dimension_Between_PSM_and_PIM_Controller_Model()));
        refineMergeControllerActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Merge PIM & PSM Controller Models",templateRegistry.Merge_PIM_and_PSM_Models()));
        refineMergeControllerActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Import Using Packages of Controller Model",templateRegistry.Replace_usePackage_relation_with_using_attribute()));
        phase.CreateActivity(refineMergeControllerActivity);

        var refineMergeCQRSModelActivity = Activity.Create("Refine PSM CQRS Model and Merge with PIM CQRS Model");
        refineMergeCQRSModelActivity.CreateTask(WorkUnit.CreateManualTask("Describe Implementation-Specific Concerns of CQRS Model"));
        refineMergeCQRSModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Set Relational Dimension Between PSM & PIM CQRS Models",templateRegistry.Set_Relational_Dimension_Between_PSM_and_PIM_CQRS_Model()));
        refineMergeCQRSModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Merge PIM & PSM CQRS Models",templateRegistry.Merge_PIM_and_PSM_Models()));
        refineMergeCQRSModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Import Using Packages of CQRS Model",templateRegistry.Replace_usePackage_relation_with_using_attribute()));
        phase.CreateActivity(refineMergeCQRSModelActivity);

        var refineMergeCoreDomainModelActivity = Activity.Create("Refine PSM Core Domain Model and Merge With PIM Core Domain Model");
        refineMergeCoreDomainModelActivity.CreateTask(WorkUnit.CreateManualTask("Describe Implementation-Specific Concerns of Core Domain Model"));
        refineMergeCoreDomainModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Set Relational Dimension Between PSM & PIM Core Domain Models",templateRegistry.Set_Relational_Dimension_Between_PSM_and_PIM_Core_Domain_Model()));
        refineMergeCoreDomainModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Merge PIM & PSM Core Domain Models",templateRegistry.Merge_PIM_and_PSM_Models()));
        refineMergeCoreDomainModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Import Using Packages of Core Domain Model",templateRegistry.Replace_usePackage_relation_with_using_attribute()));
        phase.CreateActivity(refineMergeCoreDomainModelActivity);

        var refineRepositoryModelActivity = Activity.Create("Refine PSM Repository Model");
        refineRepositoryModelActivity.CreateTask(WorkUnit.CreateManualTask("Describe Implementation-Specific Concerns of Repostories"));
        refineRepositoryModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Create Repository Operation",templateRegistry.Extract_Operation_From_One_to_One_to_Many_Relation()));
        refineRepositoryModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Set Repository Operation Body",templateRegistry.Extract_Operation_Attribute_From_Chain_Of_Node()));
        phase.CreateActivity(refineRepositoryModelActivity);

        var refineInterfaceModelActivity = Activity.Create("Refine PSM Interface Model");
        refineInterfaceModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map Interface Proeprty to Concept Attribute in CQRS Model",templateRegistry.Map_Interface_Property_To_Concept_Attribute()));
        refineInterfaceModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Extract Interface Operation in CQRS Model",templateRegistry.Extract_Interface_Operation_From_One_to_One_to_Many_Relation()));
        phase.CreateActivity(refineInterfaceModelActivity);
        
        process.AddPhase(phase);

        return process;
    }
    internal static Process AddCodeGenerationPhase(this Process process,IPatternInstanceTemplateRgistry templateRgistry){
        var phase = Phase.Create("Generate Code");


        process.AddPhase(phase);
        return process;
    }

    internal static Process AddCSharpCodeGenerationPhase(this Process process, IPatternInstanceTemplateRgistry templateRgistry)
    {
        var mappingPhase = Phase.Create("Mapping Phase");

        var mapPSMModelActivity = Activity.Create("Map PIM & PSM Models to the Project Code Model");
        mapPSMModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map Commands to the Files in the 'Commands' Folder",templateRgistry.Map_Commands_to_Files_In_Specific_Folder()));
        mapPSMModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map Events to the Files in the 'Events' Folder",templateRgistry.Map_Events_to_Files_In_Specific_Folder()));
        mapPSMModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map CommandHandlers to the Files in the 'Handlers' Folder",templateRgistry.Map_CommandHandlers_to_Files_In_Specific_Folder()));
        mapPSMModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map EventHandlers to the Files in the 'Handlers' Folder",templateRgistry.Map_EventHandlers_to_Files_In_Specific_Folder()));
        mapPSMModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map Repositories Defined in CQRS Model to the Files in the 'Repositories' Folder",templateRgistry.Map_Repositories_to_Files_In_Specific_Folder()));
        mapPSMModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map Services Defined in CQRS Model to the Files in the 'Services' Folder",templateRgistry.Map_Services_to_Files_In_Specific_Folder()));

        mapPSMModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map ApiControllers to the Files in the 'Controllers' Folder",templateRgistry.Map_Controllers_to_Files_In_Specific_Folder()));
        mapPSMModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map Services Defined in Controller Model to the Files in the 'Services' Folder",templateRgistry.Map_Services_to_Files_In_Specific_Folder()));

        mapPSMModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map Entities to the Files in the 'Entities' Folder",templateRgistry.Map_Entities_to_Files_In_Specific_Folder()));

        // TODO: Create CSProject File
        // TODO: Extract and Define Interface Operation in the CQRS Model
        // TODO: Extract and Define Interface Operation in the Controller Model

        mapPSMModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map Interfaces Defined in CQRS Model to the Files in the 'Interfaces' Folder",templateRgistry.Map_Interfaces_to_Files_In_Specific_Folder()));
        mapPSMModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Map Interfaces Defined in Controller Model to the Files in the 'Interfaces' Folder",templateRgistry.Map_Interfaces_to_Files_In_Specific_Folder()));




        mapPSMModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Set Relational Dimension Between the Project Files and Class Concepts",templateRgistry.Set_Relational_Dimension_Between_File_and_Class_Concept()));
        mapPSMModelActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Set Relational Dimension Between the Project Files and Interface Concepts",templateRgistry.Set_Relational_Dimension_Between_File_and_Interface_Concept()));

        mappingPhase.CreateActivity(mapPSMModelActivity);
        process.AddPhase(mappingPhase);



        var codeGenartionPhase = Phase.Create("Code Generation Phase");
        
        var generateCodeActivity = Activity.Create("Generate C# Code");
        generateCodeActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Create Project Source File",templateRgistry.Create_Project_Source_File()));
        generateCodeActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Generate C# Code for CQRS Model",templateRgistry.Generate_CSharp_Code_Of_Class_Concept()));
        generateCodeActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Generate C# Code for Controller Model",templateRgistry.Generate_CSharp_Code_Of_Class_Concept()));
        generateCodeActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Generate C# Code for Core Domain Model",templateRgistry.Generate_CSharp_Code_Of_Class_Concept()));
        generateCodeActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Generate C# Code for Interfaces of CQRS Model",templateRgistry.Generate_Csharp_Code_Of_Interface_Concept()));
        generateCodeActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Generate C# Code for Interfaces of Controller Model",templateRgistry.Generate_Csharp_Code_Of_Interface_Concept()));
        generateCodeActivity.CreateTask(WorkUnit.CreateModelTransformationTask("Generate Project Solution",templateRgistry.Merge_Two_DomainObject_Models()));
        codeGenartionPhase.CreateActivity(generateCodeActivity);
        process.AddPhase(codeGenartionPhase);

        return process;
    }
}