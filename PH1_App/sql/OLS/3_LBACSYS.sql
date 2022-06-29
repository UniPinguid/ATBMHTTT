BEGIN
    sa_sysdba.create_policy(policy_name => 'ESBD', column_name => 'rowlabel');
    
    GRANT ESBD_DBA TO "900001";
    GRANT EXECUTE ON sa_components TO "900001";
    GRANT EXECUTE ON sa_label_admin TO "900001";
    GRANT EXECUTE ON sa_user_admin TO "900001";
    GRANT EXECUTE ON char_to_label TO "900001";
    
    sa_components.create_level(policy_name => 'ESBD', long_name => 'Giam Doc So', short_name => 'GDS', level_num => 1000);
    sa_components.create_level(policy_name => 'ESBD', long_name => 'Giam Doc Co so y te', short_name => 'GDC', level_num => 3000);
    sa_components.create_level(policy_name => 'ESBD', long_name => 'Y Bac Si', short_name => 'YBS', level_num => 5000);
    
    sa_components.create_compartment(policy_name => 'ESBD', long_name => 'Dieu Tri Ngoai Tru', short_name => 'NGTRU', level_num => 10);
    sa_components.create_compartment(policy_name => 'ESBD', long_name => 'Dieu Tri Noi Tru', short_name => 'NOITRU', level_num => 50);
    sa_components.create_compartment(policy_name => 'ESBD', long_name => 'Dieu Tri Chuyen Sau', short_name => 'CHSAU', level_num => 250);
    
    
    sa_components.create_group(policy_name => 'ESBD', long_name => 'Trung Tam', short_name => 'TRT', group_num => 2000);
    sa_components.create_group(policy_name => 'ESBD', long_name => 'Can Trung Tam', short_name => 'CTT', group_num => 4000);
    sa_components.create_group(policy_name => 'ESBD', long_name => 'Ngoai Thanh', short_name => 'TRT', group_num => 6000);
    
    sa_label_admin.create_label(policy_name => 'ESBD', label_tag => 100, label_value => 'GDS: NGTRU, NOITRU, CHSAU: TRT, CTT, NGT');
    sa_label_admin.create_label(policy_name => 'ESBD', label_tag => 200, label_value => 'GDC: CHSAU: TRT');
    sa_label_admin.create_label(policy_name => 'ESBD', label_tag => 300, label_value => 'GDC: NOITRU:CTT');
    sa_label_admin.create_label(policy_name => 'ESBD', label_tag => 400, label_value => 'YBS:NGTRU: NGT');
    sa_label_admin.create_label(policy_name => 'ESBD', label_tag => 500, label_value => 'YBS: NOITRU: TRT');
    
    sa_policy_admin.apply_table_policy(policy_name => 'ESBD',schema_name => '900001',table_name => 'THONGBAO',table_options => 'NO_CONTROL');
    
    sa_user_admin.set_user_labels(policy_name => 'ESBD', user_name => 'ALL_GDS', max_read_label => 'GDS: NGTRU, NOITRU, CHSAU: TRT, CTT, NGT');
    sa_user_admin.set_user_labels(policy_name => 'ESBD', user_name => 'GD_NT_CTT', max_read_label => 'GDC: NOITRU:CTT');
    sa_user_admin.set_user_labels(policy_name => 'ESBD', user_name => 'GD_ChuyenSau_TT', max_read_label => 'GDC: CHSAU: TRT');
    sa_user_admin.set_user_labels(policy_name => 'ESBD', user_name => 'YBacSi_NgoaiTru_NgoaiThanh', max_read_label => 'YBS:NGTRU: NGT');
    sa_user_admin.set_user_labels(policy_name => 'ESBD', user_name => 'YBacSi_NoiTru_TrungTam', max_read_label => 'YBS: NOITRU: TRT');
    
END;