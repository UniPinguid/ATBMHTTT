BEGIN
sa_policy_admin.apply_table_policy(policy_name => 'ESBD', schema_name => '900001', table_name => 'THONGBAO', table_options => 'NO_CONTROL');

UPDATE THONGBAO
SET ROWLABEL = char_to_label('ESBD', 'YBS: NOITRU: TRT');

END;