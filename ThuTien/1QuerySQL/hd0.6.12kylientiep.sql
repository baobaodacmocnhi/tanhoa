select DANHBA from HOADON where CODE='4' and TIEUTHU=0 and ((NAM=2024 and ky<=2)or Nam<2024) and ((nam=2023 and ky>=9) or (nam=2024 and ky<=2)) and Quan in (23,22) group by DANHBA
having count(*)=6

select DANHBA from HOADON where CODE='4' and TIEUTHU=0 and ((NAM=2024 and ky<=2)or Nam<2024) and ((nam=2023 and ky>=3) or (nam=2024 and ky<=2)) and Quan in (23,22) group by DANHBA
having count(*)=12