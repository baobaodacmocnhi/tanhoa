select MADMA,CODH,SL=count(*) from TB_DULIEUKHACHHANG
where MADMA='TH-11-08'
group by MADMA,CODH
order by cast(CODH as int) asc