-- Chạy file này bằng SYSDBA

administer key management set keystore close;
administer key management create keystore 'C:/app/MyPC/product/21c/wallet/' identified by "19120114_19120172_19120261_19120423";
administer key management set keystore open identified by "19120114_19120172_19120261_19120423";
administer key management create key identified by "19120114_19120172_19120261_19120423" with backup;
administer key management use key 'AZ3CHpMZoE+vvwyzuwsivJwAAAAAAAAAAAAAAAAAAAAAAAAAAAAA' identified by "19120114_19120172_19120261_19120423" with backup;

/*
select key_id,activation_time from v$encryption_keys

SELECT * FROM V$ENCRYPTION_WALLET
*/

select *
  from dba_encrypted_columns