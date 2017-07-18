CREATE PROCEDURE P_RELATORIO_ICMS_IPI 
AS
BEGIN
	SELECT 
		Cfop,
		Sum(BaseIcms) as 'TotalBaseIcms',
		Sum(ValorIcms) as 'TotalIcms',
		Sum(BaseIpi) as 'TotalBaseIpi',
		Sum(ValorIpi) as 'TotalIpi'
	FROM 
		NotaFiscalItem
	GROUP BY
		Cfop
END
GO
