prompt PL/SQL Developer import file
prompt Created on 2018年8月6日 by admin
set feedback off
set define off
prompt Disabling triggers for SYS_DEPT...
alter table SYS_DEPT disable all triggers;
prompt Disabling triggers for SYS_EXCEPTION...
alter table SYS_EXCEPTION disable all triggers;
prompt Disabling triggers for SYS_LOG...
alter table SYS_LOG disable all triggers;
prompt Disabling triggers for SYS_LOG_LOGIN...
alter table SYS_LOG_LOGIN disable all triggers;
prompt Disabling triggers for SYS_MENU...
alter table SYS_MENU disable all triggers;
prompt Disabling triggers for SYS_MENU_OPT...
alter table SYS_MENU_OPT disable all triggers;
prompt Disabling triggers for SYS_RIGHT...
alter table SYS_RIGHT disable all triggers;
prompt Disabling triggers for SYS_RIGHT_OPT...
alter table SYS_RIGHT_OPT disable all triggers;
prompt Disabling triggers for SYS_ROLE...
alter table SYS_ROLE disable all triggers;
prompt Disabling triggers for SYS_USER...
alter table SYS_USER disable all triggers;
prompt Disabling triggers for SYS_USER_ROLE...
alter table SYS_USER_ROLE disable all triggers;
prompt Loading SYS_DEPT...
insert into SYS_DEPT (create_time, dept_code, dept_name, parent_code, site_code, site_name, dept_sort, dept_type, dept_desc, is_able, is_end, create_user, lm_user, lm_time)
values (to_date('01-08-2018 19:21:49', 'dd-mm-yyyy hh24:mi:ss'), '0000000000', '顶级节点目录', '0000000000', null, null, 0, 'LOCAL', '顶级节点，不能删除', 1, 0, 'ADMIN', 'ADMIN', to_date('01-08-2018 19:21:49', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_DEPT (create_time, dept_code, dept_name, parent_code, site_code, site_name, dept_sort, dept_type, dept_desc, is_able, is_end, create_user, lm_user, lm_time)
values (to_date('01-08-2018 19:57:08', 'dd-mm-yyyy hh24:mi:ss'), 'QIAOYUE', '乔岳软件', 'BOZHON', null, null, 1, 'LOCAL', null, 1, 0, 'ADMIN', 'ADMIN', to_date('01-08-2018 19:57:08', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_DEPT (create_time, dept_code, dept_name, parent_code, site_code, site_name, dept_sort, dept_type, dept_desc, is_able, is_end, create_user, lm_user, lm_time)
values (to_date('01-08-2018 19:57:54', 'dd-mm-yyyy hh24:mi:ss'), 'ZCGH', '整场规划', 'QIAOYUE', null, null, 1, 'LOCAL', null, 1, 1, 'ADMIN', 'ADMIN', to_date('01-08-2018 19:58:38', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_DEPT (create_time, dept_code, dept_name, parent_code, site_code, site_name, dept_sort, dept_type, dept_desc, is_able, is_end, create_user, lm_user, lm_time)
values (to_date('01-08-2018 19:56:45', 'dd-mm-yyyy hh24:mi:ss'), 'BOZHON', '博众集团', '0000000000', null, null, 1, 'LOCAL', '博众集团', 1, 0, 'ADMIN', 'ADMIN', to_date('01-08-2018 19:56:45', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_DEPT (create_time, dept_code, dept_name, parent_code, site_code, site_name, dept_sort, dept_type, dept_desc, is_able, is_end, create_user, lm_user, lm_time)
values (to_date('01-08-2018 19:58:13', 'dd-mm-yyyy hh24:mi:ss'), 'XXH', '信息化', 'QIAOYUE', null, null, 2, 'LOCAL', null, 1, 1, 'ADMIN', 'ADMIN', to_date('01-08-2018 19:58:13', 'dd-mm-yyyy hh24:mi:ss'));
commit;
prompt 5 records loaded
prompt Loading SYS_EXCEPTION...
insert into SYS_EXCEPTION (create_time, ex_id, ex_helplink, ex_message, ex_source, ex_stack, ex_target, ex_data, ex_namespace, ex_class, ex_method, ex_type, ex_desc, create_user, lm_user, lm_time)
values (to_date('01-08-2018 15:13:34', 'dd-mm-yyyy hh24:mi:ss'), '8106E839-4EE8-BCC7-B2A7-06C247C9E572', null, 'ORA-01722: 无效数字', 'BZ.DbHelper', '   在 BZ.DbHelper.PersistBroker.AbstractPersistBroker.Execute(String commandText) 位置 D:\zzh\webform\SYSTemplate\BZ.DbHelper\PersistBroker\AbstractPersistBroker.cs:行号 139' || chr(13) || '' || chr(10) || '   在 BZ.DbHelper.DataProvider.SQLDataProvider.CustomExecute(Condition condition) 位置 D:\zzh\webform\SYSTemplate\BZ.DbHelper\DataProvider\SQLDataProvider.cs:行号 106' || chr(13) || '' || chr(10) || '   在 BZ.Repository.admin.SysRightRep.ClearUnusedRightOpt() 位置 D:\zzh\webform\SYSTemplate\BZ.Repository\admin\SysRightRep.cs:行号 56' || chr(13) || '' || chr(10) || '   在 BZ.App.admin.SysMenuApp.Delete(String menuId) 位置 D:\zzh\webform\SYSTemplate\BZ.App\admin\SysMenuApp.cs:行号 93', 'Void Execute(System.String)', 'System.Collections.ListDictionaryInternal', 'BZ.App.admin.SysMenuApp', 'SysMenuApp', 'Delete', 'SysMenu|菜单管理', '8040E639-0D4A-E127-A967-46FE8A99D467:删除系统菜单失败', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:13:34', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_EXCEPTION (create_time, ex_id, ex_helplink, ex_message, ex_source, ex_stack, ex_target, ex_data, ex_namespace, ex_class, ex_method, ex_type, ex_desc, create_user, lm_user, lm_time)
values (to_date('01-08-2018 19:51:11', 'dd-mm-yyyy hh24:mi:ss'), '8007E839-9E12-5F0F-2553-4F87B7870CFE', null, 'ORA-01747: user.table.column, table.column 或列说明无效', 'BZ.DbHelper', '   在 BZ.DbHelper.PersistBroker.OraclePersistBroker.ExecuteWithReturn(String commandText, String[] parameterNames, Type[] parameterTypes, Int32[] parameterSizes, Object[] parameterValues) 位置 D:\zzh\webform\SYSTemplate\BZ.DbHelper\PersistBroker\OraclePersistBroker.cs:行号 68' || chr(13) || '' || chr(10) || '   在 BZ.DbHelper.DataProvider.SQLDataProvider.CustomExecuteWithReturn(Condition condition) 位置 D:\zzh\webform\SYSTemplate\BZ.DbHelper\DataProvider\SQLDataProvider.cs:行号 138' || chr(13) || '' || chr(10) || '   在 BZ.Repository.admin.SysDeptRep.Edit(SysDeptModel model) 位置 D:\zzh\webform\SYSTemplate\BZ.Repository\admin\SysDeptRep.cs:行号 98' || chr(13) || '' || chr(10) || '   在 BZ.App.admin.SysDeptApp.Edit(String dept_code, String name, String parent_code, String site_code, String site_name, Int32 sort, String type, String desc, Boolean isAble, Boolean isEnd)', 'Int32 ExecuteWithReturn(System.String, System.String[], System.Type[], Int32[], System.Object[])', 'System.Collections.ListDictionaryInternal', 'BZ.App.admin.SysDeptApp', 'SysDeptApp', 'Edit', 'SysDept|部门管理', 'sdfsd:更新部门信息失败', 'ADMIN', 'ADMIN', to_date('01-08-2018 19:51:11', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_EXCEPTION (create_time, ex_id, ex_helplink, ex_message, ex_source, ex_stack, ex_target, ex_data, ex_namespace, ex_class, ex_method, ex_type, ex_desc, create_user, lm_user, lm_time)
values (to_date('01-08-2018 15:15:11', 'dd-mm-yyyy hh24:mi:ss'), '8306E839-F860-2F87-37E6-CE4304ECB933', null, 'ORA-01722: 无效数字', 'BZ.DbHelper', '   在 BZ.DbHelper.PersistBroker.AbstractPersistBroker.Execute(String commandText) 位置 D:\zzh\webform\SYSTemplate\BZ.DbHelper\PersistBroker\AbstractPersistBroker.cs:行号 139' || chr(13) || '' || chr(10) || '   在 BZ.DbHelper.DataProvider.SQLDataProvider.CustomExecute(Condition condition) 位置 D:\zzh\webform\SYSTemplate\BZ.DbHelper\DataProvider\SQLDataProvider.cs:行号 106' || chr(13) || '' || chr(10) || '   在 BZ.Repository.admin.SysRightRep.ClearUnusedRightOpt() 位置 D:\zzh\webform\SYSTemplate\BZ.Repository\admin\SysRightRep.cs:行号 56' || chr(13) || '' || chr(10) || '   在 BZ.App.admin.SysMenuApp.Delete(String menuId) 位置 D:\zzh\webform\SYSTemplate\BZ.App\admin\SysMenuApp.cs:行号 93', 'Void Execute(System.String)', 'System.Collections.ListDictionaryInternal', 'BZ.App.admin.SysMenuApp', 'SysMenuApp', 'Delete', 'SysMenu|菜单管理', '9EF9E539-87E0-406F-561A-0C328507822A:删除系统菜单失败', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:15:11', 'dd-mm-yyyy hh24:mi:ss'));
commit;
prompt 3 records loaded
prompt Loading SYS_LOG...
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:13:44', 'dd-mm-yyyy hh24:mi:ss'), '8206E839-6F0E-AA74-9844-8A79BB5246C3', 'ADMIN', '菜单删除成功', 'SUCCESS', 'DELETE|删除', 'SysMenu|菜单管理', '8040E639-0D4A-E127-A967-46FE8A99D467:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:13:44', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:19:59', 'dd-mm-yyyy hh24:mi:ss'), '8706E839-4FC6-AF43-AB8A-97C18E710392', 'ADMIN', '菜单修改成功', 'SUCCESS', 'UPDATE|更新', 'SysMenu|菜单管理', 'D09EE739-E756-27A7-9EF5-EB9C1EEAA06D:修改系统菜单', null, 'SysMenuApp', 'Edit', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:19:59', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:20:57', 'dd-mm-yyyy hh24:mi:ss'), '8806E839-4AAB-EC4E-EE90-03F433B03BC0', 'ADMIN', '菜单删除成功', 'SUCCESS', 'DELETE|删除', 'SysMenu|菜单管理', 'CF9EE739-1B0C-EB1D-91FC-C22D50159684:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:20:57', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:52:37', 'dd-mm-yyyy hh24:mi:ss'), 'A506E839-9CA9-A312-C3FA-5C33FEFFCDFC', 'ADMIN', '该菜单下有子菜单，请先删除子菜单 ', 'FAIL', 'DELETE|删除', 'SysMenu|菜单管理', '34F4E539-2195-ABA3-5504-03779D86ED95:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:52:37', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 16:33:11', 'dd-mm-yyyy hh24:mi:ss'), 'CA06E839-94CC-77A8-8D80-04FEAB464A80', 'ADMIN', '操作成功', 'SUCCESS', 'UPDATE|更新', 'SysRight|权限管理', '分配角色权限', null, 'SysRightApp', 'UpdateRight', 'ADMIN', 'ADMIN', to_date('01-08-2018 16:33:11', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 16:33:14', 'dd-mm-yyyy hh24:mi:ss'), 'CA06E839-F3D7-9662-A682-A5EAF344A0E2', 'ADMIN', '操作成功', 'SUCCESS', 'UPDATE|更新', 'SysRight|权限管理', '分配角色权限', null, 'SysRightApp', 'UpdateRight', 'ADMIN', 'ADMIN', to_date('01-08-2018 16:33:14', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 19:54:11', 'dd-mm-yyyy hh24:mi:ss'), '8207E839-65CF-A73B-384A-91CC3DF89242', 'ADMIN', '添加成功', 'SUCCESS', 'CREATE|创建', 'SysDept|部门管理', '添加部门信息:tte', null, 'SysDeptApp', 'Insert', 'ADMIN', 'ADMIN', to_date('01-08-2018 19:54:11', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 19:57:08', 'dd-mm-yyyy hh24:mi:ss'), '8507E839-E081-D210-ED6D-451D79E011B1', 'ADMIN', '添加成功', 'SUCCESS', 'CREATE|创建', 'SysDept|部门管理', '添加部门信息:QIAOYUE', null, 'SysDeptApp', 'Insert', 'ADMIN', 'ADMIN', to_date('01-08-2018 19:57:08', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 19:57:55', 'dd-mm-yyyy hh24:mi:ss'), '8607E839-3539-315A-A182-6740F3628CC8', 'ADMIN', '添加成功', 'SUCCESS', 'CREATE|创建', 'SysDept|部门管理', '添加部门信息:ZCGH', null, 'SysDeptApp', 'Insert', 'ADMIN', 'ADMIN', to_date('01-08-2018 19:57:55', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 20:13:31', 'dd-mm-yyyy hh24:mi:ss'), '9407E839-9F82-0093-418F-1123D97E11A4', 'ADMIN', '更新成功', 'SUCCESS', 'CREATE|创建', 'SysUser|用户管理', '设定用户部门', null, 'SysUserApp', 'UpdateUserDept', 'ADMIN', 'ADMIN', to_date('01-08-2018 20:13:31', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 20:16:26', 'dd-mm-yyyy hh24:mi:ss'), '9707E839-1431-12D4-BEE6-D95D4D422EE5', 'ADMIN', '菜单添加成功', 'SUCCESS', 'CREATE|创建', 'SysMenu|菜单管理', 'adsfs:添加系统菜单', null, 'SysMenuApp', 'Insert', 'ADMIN', 'ADMIN', to_date('01-08-2018 20:16:26', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 20:16:55', 'dd-mm-yyyy hh24:mi:ss'), '9707E839-E19E-E71E-FA4D-66DD81000265', 'ADMIN', '菜单添加成功', 'SUCCESS', 'CREATE|创建', 'SysMenu|菜单管理', 'efdfd:添加系统菜单', null, 'SysMenuApp', 'Insert', 'ADMIN', 'ADMIN', to_date('01-08-2018 20:16:55', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('02-08-2018 08:51:36', 'dd-mm-yyyy hh24:mi:ss'), '4A0AE839-888A-A363-B1ED-2B89CB7D92BD', 'ADMIN', '添加操作码成功', 'SUCCESS', 'CREATE|创建', 'SysMenuOpt|菜单按钮管理', 'B753E139-3499-91FB-3A81-4F25EFEC4763:Insert:添加操作码', null, 'SysMenuOptApp', 'Insert', 'ADMIN', 'ADMIN', to_date('02-08-2018 08:51:36', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('02-08-2018 09:08:15', 'dd-mm-yyyy hh24:mi:ss'), '590AE839-22C9-0218-9BF4-BD6698255F2C', 'ADMIN', '添加操作码成功', 'SUCCESS', 'CREATE|创建', 'SysMenuOpt|菜单按钮管理', 'B753E139-3499-91FB-3A81-4F25EFEC4763:Del:添加操作码', null, 'SysMenuOptApp', 'Insert', 'ADMIN', 'ADMIN', to_date('02-08-2018 09:08:15', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('02-08-2018 09:08:27', 'dd-mm-yyyy hh24:mi:ss'), '590AE839-23F6-A484-3B0F-C96FD6A28368', 'ADMIN', '操作成功', 'SUCCESS', 'UPDATE|更新', 'SysRight|权限管理', '分配角色权限', null, 'SysRightApp', 'UpdateRight', 'ADMIN', 'ADMIN', to_date('02-08-2018 09:08:27', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 10:16:12', 'dd-mm-yyyy hh24:mi:ss'), '7105E839-73A9-3D11-784F-CA6F8E6B8C4E', 'ADMIN', '登录成功', 'SUCCESS', 'SELECT|查找', 'Login|用户登陆', 'ADMIN:127.0.0.1', null, 'AccountApp', 'Login', 'ADMIN', 'ADMIN', to_date('01-08-2018 10:16:12', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 14:36:50', 'dd-mm-yyyy hh24:mi:ss'), '6006E839-3347-95B9-45F2-AA4272AD5A8E', 'ADMIN', '添加用户成功', 'SUCCESS', 'CREATE|创建', 'SysUser|用户管理', '添加用户', null, 'SysUserApp', 'Insert', 'ADMIN', 'ADMIN', to_date('01-08-2018 14:36:50', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 14:40:46', 'dd-mm-yyyy hh24:mi:ss'), '6306E839-76DF-E5F6-4897-3BC11269C3C5', 'ADMIN', '删除成功', 'SUCCESS', 'CREATE|创建', 'SysUser|用户管理', '删除用户', null, 'SysUserApp', 'Delete', 'ADMIN', 'ADMIN', to_date('01-08-2018 14:40:46', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 14:51:10', 'dd-mm-yyyy hh24:mi:ss'), '6D06E839-4967-D17F-C491-485C1A7279F6', 'ADMIN', '添加用户成功', 'SUCCESS', 'CREATE|创建', 'SysUser|用户管理', '添加用户', null, 'SysUserApp', 'Insert', 'ADMIN', 'ADMIN', to_date('01-08-2018 14:51:10', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 14:51:50', 'dd-mm-yyyy hh24:mi:ss'), '6E06E839-3801-87CB-A954-4F97706FF6BE', 'ADMIN', '删除成功', 'SUCCESS', 'CREATE|创建', 'SysUser|用户管理', '删除用户', null, 'SysUserApp', 'Delete', 'ADMIN', 'ADMIN', to_date('01-08-2018 14:51:50', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 14:52:02', 'dd-mm-yyyy hh24:mi:ss'), '6E06E839-7632-91D5-EA62-C01E2E661834', 'ADMIN', '修改用户成功', 'SUCCESS', 'CREATE|创建', 'SysUser|用户管理', '修改用户', null, 'SysUserApp', 'Edit', 'ADMIN', 'ADMIN', to_date('01-08-2018 14:52:02', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 14:52:57', 'dd-mm-yyyy hh24:mi:ss'), '6F06E839-0709-F338-C254-F232C047D3EC', 'ADMIN', '修改用户成功', 'SUCCESS', 'CREATE|创建', 'SysUser|用户管理', '修改用户', null, 'SysUserApp', 'Edit', 'ADMIN', 'ADMIN', to_date('01-08-2018 14:52:57', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('02-08-2018 08:52:16', 'dd-mm-yyyy hh24:mi:ss'), '4B0AE839-0627-B381-4D77-8806A50809C0', 'ADMIN', '操作成功', 'SUCCESS', 'UPDATE|更新', 'SysRight|权限管理', '分配角色权限', null, 'SysRightApp', 'UpdateRight', 'ADMIN', 'ADMIN', to_date('02-08-2018 08:52:16', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('03-08-2018 09:32:29', 'dd-mm-yyyy hh24:mi:ss'), '960FE839-0554-A703-FFA7-6EDE6AB97E97', 'ADMIN', '菜单删除成功', 'SUCCESS', 'DELETE|删除', 'SysMenu|菜单管理', '7B63E139-7BE9-E986-E1E9-7BDEDEFD426F:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('03-08-2018 09:32:29', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('03-08-2018 09:32:36', 'dd-mm-yyyy hh24:mi:ss'), '960FE839-5872-8E6E-BF4E-E6E997F92F19', 'ADMIN', '该菜单下有子菜单，请先删除子菜单 ', 'FAIL', 'DELETE|删除', 'SysMenu|菜单管理', '03CBE539-D04D-E8FF-CCB3-B804446C7F17:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('03-08-2018 09:32:36', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('03-08-2018 09:32:45', 'dd-mm-yyyy hh24:mi:ss'), '960FE839-D594-1ABF-EC5F-63D9AD398361', 'ADMIN', '菜单删除成功', 'SUCCESS', 'DELETE|删除', 'SysMenu|菜单管理', '03CBE539-D04D-E8FF-CCB3-B804446C7F17:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('03-08-2018 09:32:45', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 14:39:12', 'dd-mm-yyyy hh24:mi:ss'), '6206E839-2D71-0CDE-C08A-C57737980F3F', 'ADMIN', '添加用户成功', 'SUCCESS', 'CREATE|创建', 'SysUser|用户管理', '添加用户', null, 'SysUserApp', 'Insert', 'ADMIN', 'ADMIN', to_date('01-08-2018 14:39:12', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:13:34', 'dd-mm-yyyy hh24:mi:ss'), '8106E839-A7E8-4BA4-BA53-9BF32116F6B5', 'ADMIN', 'ORA-01722: 无效数字', 'FAIL', 'DELETE|删除', 'SysMenu|菜单管理', '8040E639-0D4A-E127-A967-46FE8A99D467:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:13:34', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:15:15', 'dd-mm-yyyy hh24:mi:ss'), '8306E839-6072-44AA-AB86-A5B73A5FB9DC', 'ADMIN', '菜单删除成功', 'SUCCESS', 'DELETE|删除', 'SysMenu|菜单管理', '9EF9E539-87E0-406F-561A-0C328507822A:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:15:15', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:19:16', 'dd-mm-yyyy hh24:mi:ss'), '8706E839-4421-054D-12B5-AA4FDC5CE63C', 'ADMIN', '菜单删除成功', 'SUCCESS', 'DELETE|删除', 'SysMenu|菜单管理', '094FE539-D86E-BF02-14F5-9B01A176F8DA:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:19:16', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:19:28', 'dd-mm-yyyy hh24:mi:ss'), '8706E839-D64D-B38D-5646-9F7DE20942E2', 'ADMIN', '菜单删除成功', 'SUCCESS', 'DELETE|删除', 'SysMenu|菜单管理', '084FE539-AB7C-3B9A-AA48-9B71BF9375AB:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:19:28', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:20:26', 'dd-mm-yyyy hh24:mi:ss'), '8806E839-F731-963A-8ED4-A67D8464B3B4', 'ADMIN', '菜单修改成功', 'SUCCESS', 'UPDATE|更新', 'SysMenu|菜单管理', 'D09EE739-E756-27A7-9EF5-EB9C1EEAA06D:修改系统菜单', null, 'SysMenuApp', 'Edit', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:20:26', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:36:39', 'dd-mm-yyyy hh24:mi:ss'), '9706E839-D509-9109-AC0C-DAAEA7C99CEF', 'ADMIN', '菜单名称或编码已存在', 'SUCCESS', 'CREATE|创建', 'SysMenu|菜单管理', 'labelPrinter:添加系统菜单', null, 'SysMenuApp', 'Insert', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:36:39', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:38:27', 'dd-mm-yyyy hh24:mi:ss'), '9806E839-73AE-2B00-38E2-14F7CD8B33E5', 'ADMIN', '菜单名称或编码已存在', 'SUCCESS', 'CREATE|创建', 'SysMenu|菜单管理', 'labelPrinter:添加系统菜单', null, 'SysMenuApp', 'Insert', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:38:27', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:39:25', 'dd-mm-yyyy hh24:mi:ss'), '9906E839-1493-5CD4-6975-A979C05A8088', 'ADMIN', '菜单名称或编码已存在', 'FAIL', 'CREATE|创建', 'SysMenu|菜单管理', 'labelPrinter:添加系统菜单', null, 'SysMenuApp', 'Insert', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:39:25', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 16:22:35', 'dd-mm-yyyy hh24:mi:ss'), 'C106E839-6F16-F97A-70E5-BB1898788272', 'ADMIN', '角色添加成功', 'SUCCESS', 'CREATE|创建', 'SysRole|角色设定', '添加角色信息', null, 'SysRoleApp', 'Insert', 'ADMIN', 'ADMIN', to_date('01-08-2018 16:22:35', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 16:22:46', 'dd-mm-yyyy hh24:mi:ss'), 'C106E839-3B42-C4E4-71C8-D7E42E859542', 'ADMIN', '分配成功', 'SUCCESS', 'UPDATE|更新', 'SysRole|角色设定', '用户分配角色', null, 'SysRoleApp', 'AllotSysUserRole', 'ADMIN', 'ADMIN', to_date('01-08-2018 16:22:46', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 16:31:56', 'dd-mm-yyyy hh24:mi:ss'), 'C906E839-4BA5-870C-BE92-B2FFC5ED352C', 'ADMIN', '操作成功', 'SUCCESS', 'UPDATE|更新', 'SysRight|权限管理', '分配角色权限', null, 'SysRightApp', 'UpdateRight', 'ADMIN', 'ADMIN', to_date('01-08-2018 16:31:56', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 16:32:27', 'dd-mm-yyyy hh24:mi:ss'), 'CA06E839-AB20-01BC-C5F8-92AA6F5A0B64', 'ADMIN', '操作成功', 'SUCCESS', 'UPDATE|更新', 'SysRight|权限管理', '分配角色权限', null, 'SysRightApp', 'UpdateRight', 'ADMIN', 'ADMIN', to_date('01-08-2018 16:32:27', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 19:46:05', 'dd-mm-yyyy hh24:mi:ss'), '7B07E839-3665-EA09-2039-EA1F15C56A90', 'ADMIN', '添加失败，部门编号或名称已存在', 'FAIL', 'CREATE|创建', 'SysDept|部门管理', '添加部门信息:', null, 'SysDeptApp', 'Insert', 'ADMIN', 'ADMIN', to_date('01-08-2018 19:46:05', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 19:47:47', 'dd-mm-yyyy hh24:mi:ss'), '7C07E839-B5F2-41C1-495C-6CD0FBFB5453', 'ADMIN', '添加失败，部门编号或名称已存在', 'FAIL', 'CREATE|创建', 'SysDept|部门管理', '添加部门信息:sdfsd', null, 'SysDeptApp', 'Insert', 'ADMIN', 'ADMIN', to_date('01-08-2018 19:47:47', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 19:48:44', 'dd-mm-yyyy hh24:mi:ss'), '7D07E839-E4D3-8E67-7CAD-CCED9C22478A', 'ADMIN', '添加成功', 'SUCCESS', 'CREATE|创建', 'SysDept|部门管理', '添加部门信息:sdfsd', null, 'SysDeptApp', 'Insert', 'ADMIN', 'ADMIN', to_date('01-08-2018 19:48:44', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 19:51:11', 'dd-mm-yyyy hh24:mi:ss'), '8007E839-DF12-B2FD-20B8-629B30528DD4', 'ADMIN', 'ORA-01747: user.table.column, table.column 或列说明无效', 'FAIL', 'UPDATE|更新', 'SysDept|部门管理', 'sdfsd:更新部门信息', null, 'SysDeptApp', 'Edit', 'ADMIN', 'ADMIN', to_date('01-08-2018 19:51:11', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 19:53:41', 'dd-mm-yyyy hh24:mi:ss'), '8207E839-2D5B-AB4B-8A4C-0168B48EB384', 'ADMIN', '更新成功', 'SUCCESS', 'UPDATE|更新', 'SysDept|部门管理', 'sdfsd:更新部门信息', null, 'SysDeptApp', 'Edit', 'ADMIN', 'ADMIN', to_date('01-08-2018 19:53:41', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 19:54:28', 'dd-mm-yyyy hh24:mi:ss'), '8307E839-D312-6287-A4E9-15840E28D90F', 'ADMIN', '删除失败，该部门下存在子部门，请先删除子部门', 'FAIL', 'DELETE|删除', 'SysDept|部门管理', 'sdfsd:删除部门信息', null, 'SysDeptApp', 'Delete', 'ADMIN', 'ADMIN', to_date('01-08-2018 19:54:28', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 19:56:45', 'dd-mm-yyyy hh24:mi:ss'), '8507E839-7528-6047-A333-C10E396D2E2A', 'ADMIN', '添加成功', 'SUCCESS', 'CREATE|创建', 'SysDept|部门管理', '添加部门信息:BOZHON', null, 'SysDeptApp', 'Insert', 'ADMIN', 'ADMIN', to_date('01-08-2018 19:56:45', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 19:58:13', 'dd-mm-yyyy hh24:mi:ss'), '8607E839-5880-B607-C300-F2FE96E172F2', 'ADMIN', '添加成功', 'SUCCESS', 'CREATE|创建', 'SysDept|部门管理', '添加部门信息:XXH', null, 'SysDeptApp', 'Insert', 'ADMIN', 'ADMIN', to_date('01-08-2018 19:58:13', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 19:58:20', 'dd-mm-yyyy hh24:mi:ss'), '8607E839-9A9D-5BAE-53D8-F836BC1FDCDA', 'ADMIN', '删除失败，该部门下存在子部门，请先删除子部门', 'FAIL', 'DELETE|删除', 'SysDept|部门管理', 'QIAOYUE:删除部门信息', null, 'SysDeptApp', 'Delete', 'ADMIN', 'ADMIN', to_date('01-08-2018 19:58:20', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 19:58:29', 'dd-mm-yyyy hh24:mi:ss'), '8607E839-49BE-37CF-0576-E04BA9683AB4', 'ADMIN', '更新成功', 'SUCCESS', 'UPDATE|更新', 'SysDept|部门管理', 'ZCGH:更新部门信息', null, 'SysDeptApp', 'Edit', 'ADMIN', 'ADMIN', to_date('01-08-2018 19:58:29', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 19:58:38', 'dd-mm-yyyy hh24:mi:ss'), '8607E839-99E3-3E15-1A1E-BB7CC335E6A9', 'ADMIN', '更新成功', 'SUCCESS', 'UPDATE|更新', 'SysDept|部门管理', 'ZCGH:更新部门信息', null, 'SysDeptApp', 'Edit', 'ADMIN', 'ADMIN', to_date('01-08-2018 19:58:38', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 20:31:57', 'dd-mm-yyyy hh24:mi:ss'), 'A507E839-8A65-FA9C-24DA-BE6768932FDD', 'ADMIN', '更新成功', 'SUCCESS', 'CREATE|创建', 'SysUser|用户管理', '设定用户部门', null, 'SysUserApp', 'UpdateUserDept', 'ADMIN', 'ADMIN', to_date('01-08-2018 20:31:57', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 20:32:04', 'dd-mm-yyyy hh24:mi:ss'), 'A507E839-C580-5D63-B4BF-F7A2573FC2E7', 'ADMIN', '更新成功', 'SUCCESS', 'CREATE|创建', 'SysUser|用户管理', '设定用户部门', null, 'SysUserApp', 'UpdateUserDept', 'ADMIN', 'ADMIN', to_date('01-08-2018 20:32:04', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('02-08-2018 09:06:43', 'dd-mm-yyyy hh24:mi:ss'), '580AE839-7F62-6264-66AA-B535CE520C71', 'A1507123', '添加用户成功', 'SUCCESS', 'CREATE|创建', 'SysUser|用户管理', '添加用户', null, 'SysUserApp', 'Insert', 'A1507123', 'A1507123', to_date('02-08-2018 09:06:43', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('02-08-2018 09:09:33', 'dd-mm-yyyy hh24:mi:ss'), '5A0AE839-F1F9-08CC-4A8B-B57ACB8BCBD3', 'A1507123', '删除成功', 'SUCCESS', 'CREATE|创建', 'SysUser|用户管理', 'A1507111:删除用户', null, 'SysUserApp', 'Delete', 'A1507123', 'A1507123', to_date('02-08-2018 09:09:33', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('02-08-2018 14:09:16', 'dd-mm-yyyy hh24:mi:ss'), '6D0BE839-835C-162D-48D3-67F9DC7F7E4F', 'ADMIN', '旧密码不正确', 'FAIL', 'UPDATE|更新', 'SysUser|用户管理', '用户修改密码', null, 'SysUserApp', 'EditPassword', 'ADMIN', 'ADMIN', to_date('02-08-2018 14:09:16', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('02-08-2018 14:10:23', 'dd-mm-yyyy hh24:mi:ss'), '6E0BE839-D163-11F0-98A1-63F2489D7362', 'ADMIN', '旧密码不正确', 'FAIL', 'UPDATE|更新', 'SysUser|用户管理', '用户修改密码', null, 'SysUserApp', 'EditPassword', 'ADMIN', 'ADMIN', to_date('02-08-2018 14:10:23', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('02-08-2018 14:15:25', 'dd-mm-yyyy hh24:mi:ss'), '720BE839-2FFF-25FF-C04C-CB2696FB7BDA', 'ADMIN', '密码修改成功', 'SUCCESS', 'UPDATE|更新', 'SysUser|用户管理', '用户修改密码', null, 'SysUserApp', 'EditPassword', 'ADMIN', 'ADMIN', to_date('02-08-2018 14:15:25', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('03-08-2018 09:32:24', 'dd-mm-yyyy hh24:mi:ss'), '960FE839-5D43-FDAB-B261-7A4B3992F6C8', 'ADMIN', '菜单删除成功', 'SUCCESS', 'DELETE|删除', 'SysMenu|菜单管理', '4AE8E539-A929-1A3F-397D-93D65D87F642:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('03-08-2018 09:32:24', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('03-08-2018 09:32:33', 'dd-mm-yyyy hh24:mi:ss'), '960FE839-A566-A2F1-6185-181D510D83F9', 'ADMIN', '菜单删除成功', 'SUCCESS', 'DELETE|删除', 'SysMenu|菜单管理', '93C0E539-3B84-D095-D9F4-AD15FABE7818:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('03-08-2018 09:32:33', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('03-08-2018 09:32:41', 'dd-mm-yyyy hh24:mi:ss'), '960FE839-B084-5543-8137-01E6F2619AEB', 'ADMIN', '菜单删除成功', 'SUCCESS', 'DELETE|删除', 'SysMenu|菜单管理', '04CBE539-44C1-A4C4-E19C-E5881655ED11:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('03-08-2018 09:32:41', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('03-08-2018 09:32:49', 'dd-mm-yyyy hh24:mi:ss'), '960FE839-BAA2-D783-1E9D-21D35C1B0964', 'ADMIN', '菜单删除成功', 'SUCCESS', 'DELETE|删除', 'SysMenu|菜单管理', '1:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('03-08-2018 09:32:49', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:13:23', 'dd-mm-yyyy hh24:mi:ss'), '8106E839-7CBB-9A2B-8A80-EE41FDBC233F', 'ADMIN', '该菜单下有子菜单，请先删除子菜单 ', 'FAIL', 'DELETE|删除', 'SysMenu|菜单管理', '084FE539-AB7C-3B9A-AA48-9B71BF9375AB:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:13:23', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:53:51', 'dd-mm-yyyy hh24:mi:ss'), 'A606E839-D5C7-FAFB-3C11-ABB7EEF9DF78', 'ADMIN', '该菜单下有子菜单，请先删除子菜单 ', 'FAIL', 'DELETE|删除', 'SysMenu|菜单管理', '34F4E539-2195-ABA3-5504-03779D86ED95:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:53:51', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:54:37', 'dd-mm-yyyy hh24:mi:ss'), 'A706E839-7B7C-586D-CFC1-E85E25508E4B', 'ADMIN', '该菜单下有子菜单，请先删除子菜单 ', 'FAIL', 'DELETE|删除', 'SysMenu|菜单管理', '34F4E539-2195-ABA3-5504-03779D86ED95:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:54:37', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:54:58', 'dd-mm-yyyy hh24:mi:ss'), 'A706E839-0ED0-07B7-9014-D92E3E21D210', 'ADMIN', '菜单删除成功', 'SUCCESS', 'DELETE|删除', 'SysMenu|菜单管理', '37F4E539-4312-DCFD-1D45-9CEA85864DBB:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:54:58', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:55:01', 'dd-mm-yyyy hh24:mi:ss'), 'A706E839-1FDA-C906-0D76-922CFADC39E8', 'ADMIN', '菜单删除成功', 'SUCCESS', 'DELETE|删除', 'SysMenu|菜单管理', '34F4E539-2195-ABA3-5504-03779D86ED95:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:55:01', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 19:54:33', 'dd-mm-yyyy hh24:mi:ss'), '8307E839-0727-4648-5A61-8A096FB293EB', 'ADMIN', '删除成功', 'SUCCESS', 'DELETE|删除', 'SysDept|部门管理', 'tte:删除部门信息', null, 'SysDeptApp', 'Delete', 'ADMIN', 'ADMIN', to_date('01-08-2018 19:54:33', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 19:54:58', 'dd-mm-yyyy hh24:mi:ss'), '8307E839-2387-DEED-810D-FF42E135E778', 'ADMIN', '删除成功', 'SUCCESS', 'DELETE|删除', 'SysDept|部门管理', 'sdfsd:删除部门信息', null, 'SysDeptApp', 'Delete', 'ADMIN', 'ADMIN', to_date('01-08-2018 19:54:58', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 11:49:11', 'dd-mm-yyyy hh24:mi:ss'), 'C605E839-4DC8-107C-385A-245ED1B956A1', 'ADMIN', '修改用户成功', 'SUCCESS', 'CREATE|创建', 'SysUser|用户管理', '修改用户', null, 'SysUserApp', 'Edit', 'ADMIN', 'ADMIN', to_date('01-08-2018 11:49:11', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 14:39:03', 'dd-mm-yyyy hh24:mi:ss'), '6206E839-4C4F-BE8C-3BF1-34696E51C95F', 'ADMIN', '该用户已存在', 'FAIL', 'CREATE|创建', 'SysUser|用户管理', '添加用户', null, 'SysUserApp', 'Insert', 'ADMIN', 'ADMIN', to_date('01-08-2018 14:39:03', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:15:05', 'dd-mm-yyyy hh24:mi:ss'), '8306E839-0A4B-D0E4-2E97-32B77330E40D', 'ADMIN', '菜单修改成功', 'SUCCESS', 'UPDATE|更新', 'SysMenu|菜单管理', '9EF9E539-87E0-406F-561A-0C328507822A:修改系统菜单', null, 'SysMenuApp', 'Edit', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:15:05', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:15:11', 'dd-mm-yyyy hh24:mi:ss'), '8306E839-4F61-67EF-01E8-E974AC1FC0ED', 'ADMIN', 'ORA-01722: 无效数字', 'FAIL', 'DELETE|删除', 'SysMenu|菜单管理', '9EF9E539-87E0-406F-561A-0C328507822A:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:15:11', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:21:06', 'dd-mm-yyyy hh24:mi:ss'), '8806E839-49CD-F8E1-16BE-591E50B6DA81', 'ADMIN', '该菜单下有子菜单，请先删除子菜单 ', 'FAIL', 'DELETE|删除', 'SysMenu|菜单管理', '34F4E539-2195-ABA3-5504-03779D86ED95:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:21:06', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:35:48', 'dd-mm-yyyy hh24:mi:ss'), '9606E839-2543-1D2E-AB19-B61D4B152107', 'ADMIN', '菜单名称或编码已存在', 'SUCCESS', 'CREATE|创建', 'SysMenu|菜单管理', 'labelPrinter:添加系统菜单', null, 'SysMenuApp', 'Insert', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:35:48', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:54:50', 'dd-mm-yyyy hh24:mi:ss'), 'A706E839-BDAD-6DA6-BC90-AE18D13AB8B3', 'ADMIN', '菜单删除成功', 'SUCCESS', 'DELETE|删除', 'SysMenu|菜单管理', '659FE439-2683-60CF-BA8F-33158169BC4D:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:54:50', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('01-08-2018 15:54:54', 'dd-mm-yyyy hh24:mi:ss'), 'A706E839-95BF-4F39-9161-A2C1C0036616', 'ADMIN', '菜单删除成功', 'SUCCESS', 'DELETE|删除', 'SysMenu|菜单管理', '23D9E139-61DE-A9B8-8840-3B2FFF42CD01:删除系统菜单', null, 'SysMenuApp', 'Delete', 'ADMIN', 'ADMIN', to_date('01-08-2018 15:54:54', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('02-08-2018 14:08:43', 'dd-mm-yyyy hh24:mi:ss'), '6C0BE839-A2DC-EBF3-D072-23EBCAF3B650', 'ADMIN', '旧密码不正确', 'FAIL', 'UPDATE|更新', 'SysUser|用户管理', '用户修改密码', null, 'SysUserApp', 'EditPassword', 'ADMIN', 'ADMIN', to_date('02-08-2018 14:08:43', 'dd-mm-yyyy hh24:mi:ss'), 0);
insert into SYS_LOG (create_time, log_id, operate_id, log_msg, log_result, log_type, log_module, log_desc, log_namespace, log_class, log_method, create_user, lm_user, lm_time, json_type)
values (to_date('02-08-2018 14:10:44', 'dd-mm-yyyy hh24:mi:ss'), '6E0BE839-3EB5-AE5F-EA39-DA73DDB53CDA', 'ADMIN', '密码修改成功', 'SUCCESS', 'UPDATE|更新', 'SysUser|用户管理', '用户修改密码', null, 'SysUserApp', 'EditPassword', 'ADMIN', 'ADMIN', to_date('02-08-2018 14:10:44', 'dd-mm-yyyy hh24:mi:ss'), 0);
commit;
prompt 78 records loaded
prompt Loading SYS_LOG_LOGIN...
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('01-08-2018 16:15:32', 'dd-mm-yyyy hh24:mi:ss'), 'ba06e839-b1a2-df62-0e2c-b5bb3996cab0', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('01-08-2018 16:15:32', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('01-08-2018 20:13:08', 'dd-mm-yyyy hh24:mi:ss'), '9407e839-6e28-2275-1194-e9813e6ae066', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('01-08-2018 20:13:08', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 08:50:41', 'dd-mm-yyyy hh24:mi:ss'), '490ae839-81b3-285c-667f-d48a9e0365f2', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 08:50:41', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 09:07:56', 'dd-mm-yyyy hh24:mi:ss'), '590ae839-277f-3a22-e9a0-88ad8181d47c', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 09:07:56', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 10:39:52', 'dd-mm-yyyy hh24:mi:ss'), 'ad0ae839-64a7-a149-c3b6-980ffc991007', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 10:39:52', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 10:47:54', 'dd-mm-yyyy hh24:mi:ss'), 'b50ae839-8304-f839-02d5-3d0268f035c2', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 10:47:54', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 10:53:42', 'dd-mm-yyyy hh24:mi:ss'), 'ba0ae839-f353-e133-3a2f-f93ce41178f3', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 10:53:42', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 13:22:25', 'dd-mm-yyyy hh24:mi:ss'), '420be839-e078-897d-582a-2b866cf7adcd', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 13:22:25', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 13:25:20', 'dd-mm-yyyy hh24:mi:ss'), '450be839-1126-3955-8e37-abaa50f95e41', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 13:25:20', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 13:26:11', 'dd-mm-yyyy hh24:mi:ss'), '450be839-39ec-44bb-86f0-84facdfb053b', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 13:26:11', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 13:26:25', 'dd-mm-yyyy hh24:mi:ss'), '460be839-6522-55c4-6e0d-e908d6e6b70d', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 13:26:25', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 13:28:00', 'dd-mm-yyyy hh24:mi:ss'), '470be839-0397-d9a8-6eb0-8306ac453a05', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 13:28:00', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('01-08-2018 15:17:30', 'dd-mm-yyyy hh24:mi:ss'), '8506e839-b481-2804-713e-bfa66efb5577', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('01-08-2018 15:17:30', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 08:56:10', 'dd-mm-yyyy hh24:mi:ss'), '4e0ae839-08ba-ad17-18bf-9fe66dfed4b7', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 08:56:10', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 09:03:37', 'dd-mm-yyyy hh24:mi:ss'), '550ae839-778b-0924-a0de-6b094aab1b7d', 'A1507123', '4QrcOUm6Wau+VuBX8g+IPg==', '123456', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 09:03:37', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 10:44:52', 'dd-mm-yyyy hh24:mi:ss'), 'b20ae839-953c-5826-b5fa-35d9f0e6b4d8', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 10:44:52', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 10:50:15', 'dd-mm-yyyy hh24:mi:ss'), 'b70ae839-0c2c-9ab8-12f7-cddde5ee1600', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 10:50:15', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 14:15:02', 'dd-mm-yyyy hh24:mi:ss'), '720be839-f9a3-5fd7-8a09-5276d60e1a7c', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'FAIL', '用户名或密码错误', null, null, to_date('02-08-2018 14:15:02', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 14:29:04', 'dd-mm-yyyy hh24:mi:ss'), '7f0be839-1d7e-c7de-6755-67ea2c41f2eb', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 14:29:04', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('01-08-2018 11:07:03', 'dd-mm-yyyy hh24:mi:ss'), '9f05e839-4be9-9bb5-60d6-8bc13ac95190', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('01-08-2018 11:07:03', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('01-08-2018 11:07:29', 'dd-mm-yyyy hh24:mi:ss'), 'a005e839-609c-ccb2-0a37-71b7be2bb858', 'ADMIN', 'zOYAc0A7iUN1dzmDeWXysA==', 'admin1231', '127.0.0.1', 'FAIL', '用户名或密码错误', null, null, to_date('01-08-2018 11:07:29', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('01-08-2018 11:12:57', 'dd-mm-yyyy hh24:mi:ss'), 'a505e839-5a9f-f9d6-ee06-580630a889be', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('01-08-2018 11:12:57', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('01-08-2018 15:32:42', 'dd-mm-yyyy hh24:mi:ss'), '9306e839-a06b-48d0-a888-4f44146dfb70', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('01-08-2018 15:32:42', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('01-08-2018 16:52:15', 'dd-mm-yyyy hh24:mi:ss'), 'dc06e839-1f41-c2ed-2741-dd1eb6c31f98', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('01-08-2018 16:52:15', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('01-08-2018 19:32:02', 'dd-mm-yyyy hh24:mi:ss'), '6e07e839-6589-392e-b02e-62412f022c9f', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('01-08-2018 19:32:02', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('01-08-2018 19:47:10', 'dd-mm-yyyy hh24:mi:ss'), '7c07e839-dc61-0961-386b-c6920c8c6bf3', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('01-08-2018 19:47:10', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 09:09:26', 'dd-mm-yyyy hh24:mi:ss'), '5a0ae839-50dc-6b5b-bb79-ea57135c97d9', 'A1507123', '4QrcOUm6Wau+VuBX8g+IPg==', '123456', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 09:09:26', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 10:51:09', 'dd-mm-yyyy hh24:mi:ss'), 'b70ae839-ebfe-7b2a-fd50-bfaca7a790b5', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 10:51:09', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 13:23:50', 'dd-mm-yyyy hh24:mi:ss'), '430be839-0dc5-46db-31a6-366a27824826', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 13:23:50', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 13:24:22', 'dd-mm-yyyy hh24:mi:ss'), '440be839-1642-acf3-5cb7-878a4500ef2b', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 13:24:22', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 13:27:11', 'dd-mm-yyyy hh24:mi:ss'), '460be839-d3d7-d31f-a988-7452832061fa', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 13:27:11', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 13:27:12', 'dd-mm-yyyy hh24:mi:ss'), '460be839-6ddc-b631-2fdf-cb43e12e86c5', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 13:27:12', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 13:27:14', 'dd-mm-yyyy hh24:mi:ss'), '460be839-7be1-bb80-7a48-5e76127b90a1', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 13:27:14', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 13:27:16', 'dd-mm-yyyy hh24:mi:ss'), '460be839-d7e8-ae1c-4e64-27f799890184', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 13:27:16', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 13:27:17', 'dd-mm-yyyy hh24:mi:ss'), '460be839-87ec-c130-f10e-967b7016111f', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 13:27:17', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 13:27:18', 'dd-mm-yyyy hh24:mi:ss'), '460be839-aef0-a408-691f-934324a6bc2e', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 13:27:18', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 13:27:18', 'dd-mm-yyyy hh24:mi:ss'), '460be839-41f4-9b95-14ac-a19713068669', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 13:27:18', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 13:27:34', 'dd-mm-yyyy hh24:mi:ss'), '470be839-1532-c62b-52ff-27b1a87ec94d', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 13:27:34', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 13:27:35', 'dd-mm-yyyy hh24:mi:ss'), '470be839-1736-8457-f579-23b164b9d670', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 13:27:35', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 13:27:36', 'dd-mm-yyyy hh24:mi:ss'), '470be839-dc39-868e-a57d-608142c2404a', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 13:27:36', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 13:27:38', 'dd-mm-yyyy hh24:mi:ss'), '470be839-1242-dd3f-2104-3b4bf9a9b1c8', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 13:27:38', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 13:27:40', 'dd-mm-yyyy hh24:mi:ss'), '470be839-4447-87ff-b649-8cf0cd28b620', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 13:27:40', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 13:27:41', 'dd-mm-yyyy hh24:mi:ss'), '470be839-bd4b-9d3c-57f4-b003642cc699', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 13:27:41', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 13:27:42', 'dd-mm-yyyy hh24:mi:ss'), '470be839-cc4f-1100-5227-5912c183d6d0', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 13:27:42', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 13:27:57', 'dd-mm-yyyy hh24:mi:ss'), '470be839-8c8b-1bbb-38a7-158a09dd2cb9', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 13:27:57', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 10:42:16', 'dd-mm-yyyy hh24:mi:ss'), 'af0ae839-3fdc-2406-6d05-89efc54ddb0e', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 10:42:16', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 10:53:29', 'dd-mm-yyyy hh24:mi:ss'), 'ba0ae839-7920-25a2-f45f-3b23819834c8', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 10:53:29', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 10:55:27', 'dd-mm-yyyy hh24:mi:ss'), 'bb0ae839-5bed-1ffb-3a96-1f7ee31aa795', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 10:55:27', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('01-08-2018 19:28:38', 'dd-mm-yyyy hh24:mi:ss'), '6b07e839-416a-6eab-7b30-ae20f2977b2a', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('01-08-2018 19:28:38', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 10:49:05', 'dd-mm-yyyy hh24:mi:ss'), 'b60ae839-5117-d6ad-b956-e4dac506060e', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 10:49:05', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 14:15:07', 'dd-mm-yyyy hh24:mi:ss'), '720be839-a4b7-6d4f-6fc2-770185dd4a92', 'ADMIN', '4QrcOUm6Wau+VuBX8g+IPg==', '123456', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 14:15:07', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_LOG_LOGIN (create_time, login_id, user_code, user_pwd, user_pwd_laws, login_ip, login_result, login_msg, create_user, lm_user, lm_time)
values (to_date('02-08-2018 14:18:07', 'dd-mm-yyyy hh24:mi:ss'), '750be839-8a77-0f40-5c53-df0f4548dcd3', 'ADMIN', 'AZICOnu9cyUFFvBp3xi1AA==', 'admin123', '127.0.0.1', 'SUCCESS', '登录成功', null, null, to_date('02-08-2018 14:18:07', 'dd-mm-yyyy hh24:mi:ss'));
commit;
prompt 52 records loaded
prompt Loading SYS_MENU...
insert into SYS_MENU (create_time, menu_id, menu_code, menu_name, parent_id, menu_path, menu_icon, menu_sort, menu_type, menu_desc, is_abled, is_end, create_user, lm_user, lm_time)
values (to_date('05-09-2017 14:45:58', 'dd-mm-yyyy hh24:mi:ss'), '0', 'root', '顶级菜单', '0', null, null, 0, null, '顶级菜单根目录', 1, 0, 'ADMIN', 'ADMIN', to_date('05-09-2017 14:45:58', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_MENU (create_time, menu_id, menu_code, menu_name, parent_id, menu_path, menu_icon, menu_sort, menu_type, menu_desc, is_abled, is_end, create_user, lm_user, lm_time)
values (to_date('05-09-2017 14:45:58', 'dd-mm-yyyy hh24:mi:ss'), '1354E139-E63A-4DE5-7A5D-A5B9AA84A2DB', 'SystemManagement', '系统设置', '0', null, 'fa fa-circle-o', 99, 'PC', '系统设置', 1, 0, 'ADMIN', 'ADMIN', to_date('05-09-2017 14:45:58', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_MENU (create_time, menu_id, menu_code, menu_name, parent_id, menu_path, menu_icon, menu_sort, menu_type, menu_desc, is_abled, is_end, create_user, lm_user, lm_time)
values (to_date('05-09-2017 14:45:58', 'dd-mm-yyyy hh24:mi:ss'), 'B753E139-3499-91FB-3A81-4F25EFEC4763', 'SysUser', '用户管理', '1354E139-E63A-4DE5-7A5D-A5B9AA84A2DB', '/html/admin/sysUser/index.htm', 'fa fa-angle-double-right', 1, 'PC', '用户管理', 1, 1, 'ADMIN', 'ADMIN', to_date('05-09-2017 14:45:58', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_MENU (create_time, menu_id, menu_code, menu_name, parent_id, menu_path, menu_icon, menu_sort, menu_type, menu_desc, is_abled, is_end, create_user, lm_user, lm_time)
values (to_date('05-09-2017 14:45:58', 'dd-mm-yyyy hh24:mi:ss'), '2DA59854-7384-A4CD-B14A-39E15F03588D', 'SysMenu', '菜单管理', '1354E139-E63A-4DE5-7A5D-A5B9AA84A2DB', '/html/admin/sysMenu/index.htm', 'fa fa-angle-double-right', 2, 'PC', '菜单管理', 1, 1, 'ADMIN', 'ADMIN', to_date('05-09-2017 14:45:58', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_MENU (create_time, menu_id, menu_code, menu_name, parent_id, menu_path, menu_icon, menu_sort, menu_type, menu_desc, is_abled, is_end, create_user, lm_user, lm_time)
values (to_date('05-09-2017 14:45:58', 'dd-mm-yyyy hh24:mi:ss'), 'E853E139-6293-2733-C720-8B3667E5D0E1', 'SysRole', '角色管理', '1354E139-E63A-4DE5-7A5D-A5B9AA84A2DB', '/html/admin/sysRole/index.htm', 'fa fa-angle-double-right', 3, 'PC', '角色管理', 1, 1, 'ADMIN', 'ADMIN', to_date('05-09-2017 14:45:58', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_MENU (create_time, menu_id, menu_code, menu_name, parent_id, menu_path, menu_icon, menu_sort, menu_type, menu_desc, is_abled, is_end, create_user, lm_user, lm_time)
values (to_date('05-09-2017 14:45:58', 'dd-mm-yyyy hh24:mi:ss'), 'E853E139-6293-2733-C720-8B3667E5D0E2', 'SysRight', '权限分配', '1354E139-E63A-4DE5-7A5D-A5B9AA84A2DB', '/html/admin/sysRight/index.htm', 'fa fa-angle-double-right', 4, 'PC', '权限分配', 1, 1, 'ADMIN', 'ADMIN', to_date('05-09-2017 14:45:58', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_MENU (create_time, menu_id, menu_code, menu_name, parent_id, menu_path, menu_icon, menu_sort, menu_type, menu_desc, is_abled, is_end, create_user, lm_user, lm_time)
values (to_date('05-09-2017 14:45:58', 'dd-mm-yyyy hh24:mi:ss'), 'E953E139-153E-0CCB-6FE1-570C763431B9', 'SysDept', '部门管理', '1354E139-E63A-4DE5-7A5D-A5B9AA84A2DB', '/html/admin/sysDept/index.htm', 'fa fa-angle-double-right', 5, 'PC', '部门管理', 1, 1, 'ADMIN', 'ADMIN', to_date('05-09-2017 14:45:58', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_MENU (create_time, menu_id, menu_code, menu_name, parent_id, menu_path, menu_icon, menu_sort, menu_type, menu_desc, is_abled, is_end, create_user, lm_user, lm_time)
values (to_date('05-09-2017 14:45:58', 'dd-mm-yyyy hh24:mi:ss'), 'EA53E139-58DA-EEFF-C5E9-E684D8854DFD', 'SysLog', '系统日志', '1354E139-E63A-4DE5-7A5D-A5B9AA84A2DB', '/html/admin/sysLog/index.htm', 'fa fa-angle-double-right', 6, 'PC', '系统日志', 1, 1, 'ADMIN', 'ADMIN', to_date('05-09-2017 14:45:58', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_MENU (create_time, menu_id, menu_code, menu_name, parent_id, menu_path, menu_icon, menu_sort, menu_type, menu_desc, is_abled, is_end, create_user, lm_user, lm_time)
values (to_date('05-09-2017 14:45:58', 'dd-mm-yyyy hh24:mi:ss'), 'EB53E139-04D6-2B11-F8E6-9CC41E580E87', 'SysExpception', '系统异常', '1354E139-E63A-4DE5-7A5D-A5B9AA84A2DB', '/html/admin/sysException/index.htm', 'fa fa-angle-double-right', 7, 'PC', '系统异常', 1, 1, 'ADMIN', 'ADMIN', to_date('05-09-2017 14:45:58', 'dd-mm-yyyy hh24:mi:ss'));
commit;
prompt 9 records loaded
prompt Loading SYS_MENU_OPT...
insert into SYS_MENU_OPT (create_time, mo_code, mo_name, menu_id, is_abled, mo_desc, create_user, lm_user, lm_time)
values (to_date('02-08-2018 08:51:36', 'dd-mm-yyyy hh24:mi:ss'), 'Insert', '添加', 'B753E139-3499-91FB-3A81-4F25EFEC4763', 1, null, 'ADMIN', 'ADMIN', to_date('02-08-2018 08:51:36', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_MENU_OPT (create_time, mo_code, mo_name, menu_id, is_abled, mo_desc, create_user, lm_user, lm_time)
values (to_date('02-08-2018 09:08:15', 'dd-mm-yyyy hh24:mi:ss'), 'Del', '删除', 'B753E139-3499-91FB-3A81-4F25EFEC4763', 1, null, 'ADMIN', 'ADMIN', to_date('02-08-2018 09:08:15', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_MENU_OPT (create_time, mo_code, mo_name, menu_id, is_abled, mo_desc, create_user, lm_user, lm_time)
values (to_date('05-09-2017 17:11:37', 'dd-mm-yyyy hh24:mi:ss'), 'browse', '浏览', 'E953E139-153E-0CCB-6FE1-570C763431B9', 1, '请勿删除，默认添加项，误删除请重新添加上', 'ADMIN', 'ADMIN', to_date('05-09-2017 17:11:37', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_MENU_OPT (create_time, mo_code, mo_name, menu_id, is_abled, mo_desc, create_user, lm_user, lm_time)
values (to_date('05-09-2017 17:08:50', 'dd-mm-yyyy hh24:mi:ss'), 'browse', '浏览', '2DA59854-7384-A4CD-B14A-39E15F03588D', 1, '请勿删除，默认添加项，误删除请重新添加上', 'ADMIN', 'ADMIN', to_date('05-09-2017 17:08:50', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_MENU_OPT (create_time, mo_code, mo_name, menu_id, is_abled, mo_desc, create_user, lm_user, lm_time)
values (to_date('05-09-2017 17:09:58', 'dd-mm-yyyy hh24:mi:ss'), 'browse', '浏览', 'E853E139-6293-2733-C720-8B3667E5D0E1', 1, '请勿删除，默认添加项，误删除请重新添加上', 'ADMIN', 'ADMIN', to_date('05-09-2017 17:09:58', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_MENU_OPT (create_time, mo_code, mo_name, menu_id, is_abled, mo_desc, create_user, lm_user, lm_time)
values (to_date('05-09-2017 17:11:15', 'dd-mm-yyyy hh24:mi:ss'), 'browse', '浏览', 'E853E139-6293-2733-C720-8B3667E5D0E2', 1, '请勿删除，默认添加项，误删除请重新添加上', 'ADMIN', 'ADMIN', to_date('05-09-2017 17:11:15', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_MENU_OPT (create_time, mo_code, mo_name, menu_id, is_abled, mo_desc, create_user, lm_user, lm_time)
values (to_date('05-09-2017 17:07:45', 'dd-mm-yyyy hh24:mi:ss'), 'browse', '浏览', 'B753E139-3499-91FB-3A81-4F25EFEC4763', 1, '请勿删除，默认添加项，误删除请重新添加上', 'ADMIN', 'ADMIN', to_date('05-09-2017 17:07:45', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_MENU_OPT (create_time, mo_code, mo_name, menu_id, is_abled, mo_desc, create_user, lm_user, lm_time)
values (to_date('05-09-2017 17:11:52', 'dd-mm-yyyy hh24:mi:ss'), 'browse', '浏览', 'EA53E139-58DA-EEFF-C5E9-E684D8854DFD', 1, '请勿删除，默认添加项，误删除请重新添加上', 'ADMIN', 'ADMIN', to_date('05-09-2017 17:11:52', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_MENU_OPT (create_time, mo_code, mo_name, menu_id, is_abled, mo_desc, create_user, lm_user, lm_time)
values (to_date('05-09-2017 17:12:12', 'dd-mm-yyyy hh24:mi:ss'), 'browse', '浏览', 'EB53E139-04D6-2B11-F8E6-9CC41E580E87', 1, '请勿删除，默认添加项，误删除请重新添加上', 'ADMIN', 'ADMIN', to_date('05-09-2017 17:12:12', 'dd-mm-yyyy hh24:mi:ss'));
commit;
prompt 9 records loaded
prompt Loading SYS_RIGHT...
insert into SYS_RIGHT (create_time, menu_id, role_id, right_flag, create_user, lm_user, lm_time)
values (to_date('01-08-2018 16:22:35', 'dd-mm-yyyy hh24:mi:ss'), '1354E139-E63A-4DE5-7A5D-A5B9AA84A2DB', 'C106E839-B215-D5A0-BBD1-2EAEC0BC6111', 1, 'ADMIN', 'ADMIN', to_date('01-08-2018 16:22:35', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT (create_time, menu_id, role_id, right_flag, create_user, lm_user, lm_time)
values (to_date('01-08-2018 16:22:35', 'dd-mm-yyyy hh24:mi:ss'), 'B753E139-3499-91FB-3A81-4F25EFEC4763', 'C106E839-B215-D5A0-BBD1-2EAEC0BC6111', 1, 'ADMIN', 'ADMIN', to_date('01-08-2018 16:22:35', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT (create_time, menu_id, role_id, right_flag, create_user, lm_user, lm_time)
values (to_date('05-09-2017 16:05:01', 'dd-mm-yyyy hh24:mi:ss'), 'EA53E139-58DA-EEFF-C5E9-E684D8854DFD', '7B5DE139-45B6-AD7D-0A97-584601AA20A8', 1, 'ADMIN', 'ADMIN', to_date('05-09-2017 16:05:01', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT (create_time, menu_id, role_id, right_flag, create_user, lm_user, lm_time)
values (to_date('05-09-2017 16:05:01', 'dd-mm-yyyy hh24:mi:ss'), '2DA59854-7384-A4CD-B14A-39E15F03588D', '7B5DE139-45B6-AD7D-0A97-584601AA20A8', 1, 'ADMIN', 'ADMIN', to_date('05-09-2017 16:05:01', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT (create_time, menu_id, role_id, right_flag, create_user, lm_user, lm_time)
values (to_date('05-09-2017 16:05:01', 'dd-mm-yyyy hh24:mi:ss'), 'EB53E139-04D6-2B11-F8E6-9CC41E580E87', '7B5DE139-45B6-AD7D-0A97-584601AA20A8', 1, 'ADMIN', 'ADMIN', to_date('05-09-2017 16:05:01', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT (create_time, menu_id, role_id, right_flag, create_user, lm_user, lm_time)
values (to_date('05-09-2017 16:05:01', 'dd-mm-yyyy hh24:mi:ss'), 'E853E139-6293-2733-C720-8B3667E5D0E2', '7B5DE139-45B6-AD7D-0A97-584601AA20A8', 1, 'ADMIN', 'ADMIN', to_date('05-09-2017 16:05:01', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT (create_time, menu_id, role_id, right_flag, create_user, lm_user, lm_time)
values (to_date('05-09-2017 16:05:01', 'dd-mm-yyyy hh24:mi:ss'), 'E853E139-6293-2733-C720-8B3667E5D0E1', '7B5DE139-45B6-AD7D-0A97-584601AA20A8', 1, 'ADMIN', 'ADMIN', to_date('05-09-2017 16:05:01', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT (create_time, menu_id, role_id, right_flag, create_user, lm_user, lm_time)
values (to_date('05-09-2017 16:05:01', 'dd-mm-yyyy hh24:mi:ss'), 'E953E139-153E-0CCB-6FE1-570C763431B9', '7B5DE139-45B6-AD7D-0A97-584601AA20A8', 1, 'ADMIN', 'ADMIN', to_date('05-09-2017 16:05:01', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT (create_time, menu_id, role_id, right_flag, create_user, lm_user, lm_time)
values (to_date('01-08-2018 16:22:35', 'dd-mm-yyyy hh24:mi:ss'), 'E953E139-153E-0CCB-6FE1-570C763431B9', 'C106E839-B215-D5A0-BBD1-2EAEC0BC6111', 0, 'ADMIN', 'ADMIN', to_date('01-08-2018 16:22:35', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT (create_time, menu_id, role_id, right_flag, create_user, lm_user, lm_time)
values (to_date('05-09-2017 16:05:01', 'dd-mm-yyyy hh24:mi:ss'), '1354E139-E63A-4DE5-7A5D-A5B9AA84A2DB', '7B5DE139-45B6-AD7D-0A97-584601AA20A8', 1, 'ADMIN', 'ADMIN', to_date('05-09-2017 16:05:01', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT (create_time, menu_id, role_id, right_flag, create_user, lm_user, lm_time)
values (to_date('05-09-2017 16:05:01', 'dd-mm-yyyy hh24:mi:ss'), '0', '7B5DE139-45B6-AD7D-0A97-584601AA20A8', 1, 'ADMIN', 'ADMIN', to_date('05-09-2017 16:05:01', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT (create_time, menu_id, role_id, right_flag, create_user, lm_user, lm_time)
values (to_date('05-09-2017 16:05:01', 'dd-mm-yyyy hh24:mi:ss'), 'B753E139-3499-91FB-3A81-4F25EFEC4763', '7B5DE139-45B6-AD7D-0A97-584601AA20A8', 1, 'ADMIN', 'ADMIN', to_date('05-09-2017 16:05:01', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT (create_time, menu_id, role_id, right_flag, create_user, lm_user, lm_time)
values (to_date('01-08-2018 16:22:35', 'dd-mm-yyyy hh24:mi:ss'), '0', 'C106E839-B215-D5A0-BBD1-2EAEC0BC6111', 0, 'ADMIN', 'ADMIN', to_date('01-08-2018 16:22:35', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT (create_time, menu_id, role_id, right_flag, create_user, lm_user, lm_time)
values (to_date('01-08-2018 16:22:35', 'dd-mm-yyyy hh24:mi:ss'), 'E853E139-6293-2733-C720-8B3667E5D0E2', 'C106E839-B215-D5A0-BBD1-2EAEC0BC6111', 0, 'ADMIN', 'ADMIN', to_date('01-08-2018 16:22:35', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT (create_time, menu_id, role_id, right_flag, create_user, lm_user, lm_time)
values (to_date('01-08-2018 16:22:35', 'dd-mm-yyyy hh24:mi:ss'), 'EA53E139-58DA-EEFF-C5E9-E684D8854DFD', 'C106E839-B215-D5A0-BBD1-2EAEC0BC6111', 0, 'ADMIN', 'ADMIN', to_date('01-08-2018 16:22:35', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT (create_time, menu_id, role_id, right_flag, create_user, lm_user, lm_time)
values (to_date('01-08-2018 16:22:35', 'dd-mm-yyyy hh24:mi:ss'), '2DA59854-7384-A4CD-B14A-39E15F03588D', 'C106E839-B215-D5A0-BBD1-2EAEC0BC6111', 0, 'ADMIN', 'ADMIN', to_date('01-08-2018 16:22:35', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT (create_time, menu_id, role_id, right_flag, create_user, lm_user, lm_time)
values (to_date('01-08-2018 16:22:35', 'dd-mm-yyyy hh24:mi:ss'), 'E853E139-6293-2733-C720-8B3667E5D0E1', 'C106E839-B215-D5A0-BBD1-2EAEC0BC6111', 0, 'ADMIN', 'ADMIN', to_date('01-08-2018 16:22:35', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT (create_time, menu_id, role_id, right_flag, create_user, lm_user, lm_time)
values (to_date('01-08-2018 16:22:35', 'dd-mm-yyyy hh24:mi:ss'), 'EB53E139-04D6-2B11-F8E6-9CC41E580E87', 'C106E839-B215-D5A0-BBD1-2EAEC0BC6111', 0, 'ADMIN', 'ADMIN', to_date('01-08-2018 16:22:35', 'dd-mm-yyyy hh24:mi:ss'));
commit;
prompt 18 records loaded
prompt Loading SYS_RIGHT_OPT...
insert into SYS_RIGHT_OPT (create_time, menu_id, role_id, mo_code, is_abled, create_user, lm_user, lm_time)
values (to_date('02-08-2018 09:08:27', 'dd-mm-yyyy hh24:mi:ss'), 'B753E139-3499-91FB-3A81-4F25EFEC4763', 'C106E839-B215-D5A0-BBD1-2EAEC0BC6111', 'Del', 1, 'ADMIN', 'ADMIN', to_date('02-08-2018 09:08:27', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT_OPT (create_time, menu_id, role_id, mo_code, is_abled, create_user, lm_user, lm_time)
values (to_date('02-08-2018 08:52:16', 'dd-mm-yyyy hh24:mi:ss'), 'B753E139-3499-91FB-3A81-4F25EFEC4763', 'C106E839-B215-D5A0-BBD1-2EAEC0BC6111', 'browse', 1, 'ADMIN', 'ADMIN', to_date('02-08-2018 08:52:16', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT_OPT (create_time, menu_id, role_id, mo_code, is_abled, create_user, lm_user, lm_time)
values (to_date('02-08-2018 08:52:16', 'dd-mm-yyyy hh24:mi:ss'), 'B753E139-3499-91FB-3A81-4F25EFEC4763', 'C106E839-B215-D5A0-BBD1-2EAEC0BC6111', 'Insert', 1, 'ADMIN', 'ADMIN', to_date('02-08-2018 08:52:16', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT_OPT (create_time, menu_id, role_id, mo_code, is_abled, create_user, lm_user, lm_time)
values (to_date('12-02-2018 11:39:21', 'dd-mm-yyyy hh24:mi:ss'), 'B753E139-3499-91FB-3A81-4F25EFEC4763', '7B5DE139-45B6-AD7D-0A97-584601AA20A8', 'browse', 1, 'ADMIN', 'ADMIN', to_date('12-02-2018 11:39:21', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT_OPT (create_time, menu_id, role_id, mo_code, is_abled, create_user, lm_user, lm_time)
values (to_date('12-02-2018 11:39:35', 'dd-mm-yyyy hh24:mi:ss'), 'EA53E139-58DA-EEFF-C5E9-E684D8854DFD', '7B5DE139-45B6-AD7D-0A97-584601AA20A8', 'browse', 1, 'ADMIN', 'ADMIN', to_date('12-02-2018 11:39:35', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT_OPT (create_time, menu_id, role_id, mo_code, is_abled, create_user, lm_user, lm_time)
values (to_date('12-02-2018 11:39:26', 'dd-mm-yyyy hh24:mi:ss'), 'E853E139-6293-2733-C720-8B3667E5D0E1', '7B5DE139-45B6-AD7D-0A97-584601AA20A8', 'browse', 1, 'ADMIN', 'ADMIN', to_date('12-02-2018 11:39:26', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT_OPT (create_time, menu_id, role_id, mo_code, is_abled, create_user, lm_user, lm_time)
values (to_date('12-02-2018 11:39:24', 'dd-mm-yyyy hh24:mi:ss'), '2DA59854-7384-A4CD-B14A-39E15F03588D', '7B5DE139-45B6-AD7D-0A97-584601AA20A8', 'browse', 1, 'ADMIN', 'ADMIN', to_date('12-02-2018 11:39:24', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT_OPT (create_time, menu_id, role_id, mo_code, is_abled, create_user, lm_user, lm_time)
values (to_date('12-02-2018 11:39:33', 'dd-mm-yyyy hh24:mi:ss'), 'E953E139-153E-0CCB-6FE1-570C763431B9', '7B5DE139-45B6-AD7D-0A97-584601AA20A8', 'browse', 1, 'ADMIN', 'ADMIN', to_date('12-02-2018 11:39:33', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT_OPT (create_time, menu_id, role_id, mo_code, is_abled, create_user, lm_user, lm_time)
values (to_date('12-02-2018 11:39:30', 'dd-mm-yyyy hh24:mi:ss'), 'E853E139-6293-2733-C720-8B3667E5D0E2', '7B5DE139-45B6-AD7D-0A97-584601AA20A8', 'browse', 1, 'ADMIN', 'ADMIN', to_date('12-02-2018 11:39:30', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_RIGHT_OPT (create_time, menu_id, role_id, mo_code, is_abled, create_user, lm_user, lm_time)
values (to_date('12-02-2018 11:39:38', 'dd-mm-yyyy hh24:mi:ss'), 'EB53E139-04D6-2B11-F8E6-9CC41E580E87', '7B5DE139-45B6-AD7D-0A97-584601AA20A8', 'browse', 1, 'ADMIN', 'ADMIN', to_date('12-02-2018 11:39:38', 'dd-mm-yyyy hh24:mi:ss'));
commit;
prompt 10 records loaded
prompt Loading SYS_ROLE...
insert into SYS_ROLE (create_time, role_id, role_name, role_desc, create_user, lm_user, lm_time)
values (to_date('05-09-2017 14:36:35', 'dd-mm-yyyy hh24:mi:ss'), '7B5DE139-45B6-AD7D-0A97-584601AA20A8', 'Administrator', '系统管理员', 'ADMIN', 'ADMIN', to_date('05-09-2017 14:36:35', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_ROLE (create_time, role_id, role_name, role_desc, create_user, lm_user, lm_time)
values (to_date('01-08-2018 16:22:35', 'dd-mm-yyyy hh24:mi:ss'), 'C106E839-B215-D5A0-BBD1-2EAEC0BC6111', '测试角色', '测试', 'ADMIN', 'ADMIN', to_date('01-08-2018 16:22:35', 'dd-mm-yyyy hh24:mi:ss'));
commit;
prompt 2 records loaded
prompt Loading SYS_USER...
insert into SYS_USER (create_time, user_code, user_name, user_pwd, is_abled, is_c_pwd, user_email, user_tel, user_sex, user_post, user_desc, boss_id, dept_code, qr_code, create_user, lm_user, lm_time)
values (to_date('12-02-2018 10:55:12', 'dd-mm-yyyy hh24:mi:ss'), 'ADMIN', '管理员', 'AZICOnu9cyUFFvBp3xi1AA==', 1, 1, 'Admin@admin.com', '18362574500', 0, '管理员', '管理员账号', null, 'BOZHON', null, 'ADMIN', 'ADMIN', to_date('01-08-2018 11:49:10', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_USER (create_time, user_code, user_name, user_pwd, is_abled, is_c_pwd, user_email, user_tel, user_sex, user_post, user_desc, boss_id, dept_code, qr_code, create_user, lm_user, lm_time)
values (to_date('01-08-2018 14:36:50', 'dd-mm-yyyy hh24:mi:ss'), 'A1507123', '张忠海', '4QrcOUm6Wau+VuBX8g+IPg==', 1, 1, 'harris.zhang@boozhong.com', '18362574599', 1, '工程师', '测试账号', null, 'XXH', '622CDA52CF912FA9D22AE856CC811F18', 'ADMIN', 'ADMIN', to_date('01-08-2018 14:52:57', 'dd-mm-yyyy hh24:mi:ss'));
commit;
prompt 2 records loaded
prompt Loading SYS_USER_ROLE...
insert into SYS_USER_ROLE (create_time, user_code, role_id, create_user, lm_user, lm_time)
values (to_date('05-09-2017 14:37:09', 'dd-mm-yyyy hh24:mi:ss'), 'ADMIN', '7B5DE139-45B6-AD7D-0A97-584601AA20A8', 'ADMIN', 'ADMIN', to_date('05-09-2017 14:37:09', 'dd-mm-yyyy hh24:mi:ss'));
insert into SYS_USER_ROLE (create_time, user_code, role_id, create_user, lm_user, lm_time)
values (to_date('01-08-2018 16:22:46', 'dd-mm-yyyy hh24:mi:ss'), 'A1507123', 'C106E839-B215-D5A0-BBD1-2EAEC0BC6111', 'ADMIN', 'ADMIN', to_date('01-08-2018 16:22:46', 'dd-mm-yyyy hh24:mi:ss'));
commit;
prompt 2 records loaded
prompt Enabling triggers for SYS_DEPT...
alter table SYS_DEPT enable all triggers;
prompt Enabling triggers for SYS_EXCEPTION...
alter table SYS_EXCEPTION enable all triggers;
prompt Enabling triggers for SYS_LOG...
alter table SYS_LOG enable all triggers;
prompt Enabling triggers for SYS_LOG_LOGIN...
alter table SYS_LOG_LOGIN enable all triggers;
prompt Enabling triggers for SYS_MENU...
alter table SYS_MENU enable all triggers;
prompt Enabling triggers for SYS_MENU_OPT...
alter table SYS_MENU_OPT enable all triggers;
prompt Enabling triggers for SYS_RIGHT...
alter table SYS_RIGHT enable all triggers;
prompt Enabling triggers for SYS_RIGHT_OPT...
alter table SYS_RIGHT_OPT enable all triggers;
prompt Enabling triggers for SYS_ROLE...
alter table SYS_ROLE enable all triggers;
prompt Enabling triggers for SYS_USER...
alter table SYS_USER enable all triggers;
prompt Enabling triggers for SYS_USER_ROLE...
alter table SYS_USER_ROLE enable all triggers;
set feedback on
set define on
prompt Done.
