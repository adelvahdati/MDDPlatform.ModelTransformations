using MDDPlatform.ModelTransformations.Core.Entities;

namespace MDDPlatform.ModelTransformations.Infrastructure.Data.Seeders.PatternTemplates;

public interface IPatternInstanceTemplateRgistry
{
    PatternInstanceTemplate Convert_Controller_Endpoint_to_the_Operation_and_Attributes();
    PatternInstanceTemplate Convert_CRAC_model_to_CQRS_CommandHandler();
    PatternInstanceTemplate Convert_CRAC_model_to_CQRS_EventHandler();
    PatternInstanceTemplate Convert_CRAC_Responsibility_To_Domain_Concept_Operation();
    PatternInstanceTemplate Convert_Dispatched_Command_to_the_Controller_Endpoint();
    PatternInstanceTemplate Create_command_handler_constructor_In_CQRS_Model();
    PatternInstanceTemplate Create_Event_handler_constructor_In_CQRS_Model();
    PatternInstanceTemplate Create_handle_method_of_command_handler_In_CQRS_Model();
    PatternInstanceTemplate Create_handle_method_of_Event_handler_In_CQRS_Model();
    List<PatternInstanceTemplate> List();
    PatternInstanceTemplate Map_CRAC_Concept_To_CIM_Model();
    PatternInstanceTemplate Map_DomainConcept_Responsibility_to_the_command_dispatch_by_controller();
    PatternInstanceTemplate Map_PIM_Controller_to_PSM_Controller();
    PatternInstanceTemplate Map_PIM_CQRS_to_PSM_CQRS_CommandHandler();
    PatternInstanceTemplate Map_PIM_CQRS_to_PSM_CQRS_Commands();
    PatternInstanceTemplate Map_PIM_CQRS_to_PSM_CQRS_Event();
    PatternInstanceTemplate Map_PIM_CQRS_to_PSM_CQRS_EventHandler();
    PatternInstanceTemplate Map_PIM_Core_Domain_to_PSM_Core_Domain();
    PatternInstanceTemplate Map_PIM_Interfaces_to_PSM_Interfaces();
    PatternInstanceTemplate Merge_CIM_Concepts_With_PIM_Core_Domain();
    PatternInstanceTemplate Merge_PIM_and_PSM_Models();
    PatternInstanceTemplate Replace_Associations_With_Relation();
    PatternInstanceTemplate Replace_CIM_model_Relation_with_Property();
    PatternInstanceTemplate Replace_CQRS_Command_Relation_with_Property();
    PatternInstanceTemplate Replace_CQRS_Event_Relation_with_Property();
    PatternInstanceTemplate Replace_usePackage_relation_with_using_attribute();
    PatternInstanceTemplate Map_Commands_to_Files_In_Specific_Folder();
    PatternInstanceTemplate Map_Events_to_Files_In_Specific_Folder();
    PatternInstanceTemplate Map_CommandHandlers_to_Files_In_Specific_Folder();
    PatternInstanceTemplate Map_EventHandlers_to_Files_In_Specific_Folder();
    PatternInstanceTemplate Map_Controllers_to_Files_In_Specific_Folder();
    PatternInstanceTemplate Map_Entities_to_Files_In_Specific_Folder();
    PatternInstanceTemplate Set_Relational_Dimension_Between_File_and_Class_Concept();
    PatternInstanceTemplate Generate_CSharp_Code_Of_Class_Concept();
    PatternInstanceTemplate Map_Interfaces_to_Files_In_Specific_Folder();
    PatternInstanceTemplate Set_Relational_Dimension_Between_File_and_Interface_Concept();
    PatternInstanceTemplate Generate_Csharp_Code_Of_Interface_Concept();
    PatternInstanceTemplate Map_Repositories_to_Files_In_Specific_Folder();
    PatternInstanceTemplate Map_Services_to_Files_In_Specific_Folder();
    PatternInstanceTemplate Map_PIM_Services_to_PSM_Services();
    PatternInstanceTemplate Map_PIM_Repositories_to_PSM_Repositories();
    PatternInstanceTemplate Extract_Operation_From_One_to_One_to_Many_Relation();
    PatternInstanceTemplate Extract_Operation_Attribute_From_Chain_Of_Node();
    PatternInstanceTemplate Create_Project_Source_File();
    PatternInstanceTemplate Merge_Two_DomainObject_Models();
    PatternInstanceTemplate Map_Interface_Property_To_Concept_Attribute();
    PatternInstanceTemplate Extract_Interface_Operation_From_One_to_One_to_Many_Relation();
    PatternInstanceTemplate Set_Relational_Dimension_Between_PSM_and_PIM_Controller_Model();
    PatternInstanceTemplate Set_Relational_Dimension_Between_PSM_and_PIM_CQRS_Model();
    PatternInstanceTemplate Set_Relational_Dimension_Between_PSM_and_PIM_Core_Domain_Model();
    PatternInstanceTemplate Set_relationalDimension_Between_PIM_Entities_and_CIM_Domain_Concept();
    PatternInstanceTemplate Map_CIM_Domain_Concept_to_PIM_Entities();
}