SELECT 
    name AS ConstraintName,
    type_desc AS ConstraintType,
    referenced_object_id AS ReferencedTableID,
    delete_referential_action_desc AS DeleteAction,
    update_referential_action_desc AS UpdateAction
FROM sys.foreign_keys
WHERE parent_object_id = OBJECT_ID('Teams');



SELECT name
FROM sys.foreign_keys
WHERE parent_object_id = OBJECT_ID('dbo.Teams')
  AND type = 'F'
  AND OBJECT_NAME(referenced_object_id) = 'Tournaments';