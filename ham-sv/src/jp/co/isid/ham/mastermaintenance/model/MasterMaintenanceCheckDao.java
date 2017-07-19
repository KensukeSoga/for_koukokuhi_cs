package jp.co.isid.ham.mastermaintenance.model;

import java.math.BigDecimal;
import java.util.List;
import java.util.ArrayList;
import java.util.Map;

import jp.co.isid.ham.integ.tbl.*;
import jp.co.isid.ham.common.model.Mbj04KeiretsuVO;
import jp.co.isid.ham.common.model.Mbj26BillGroupVO;
import jp.co.isid.ham.common.model.Mbj06HcBumonVO;
import jp.co.isid.ham.common.model.Mbj29SetteiKykVO;
import jp.co.isid.ham.common.model.Mbj30InputTntVO;
import jp.co.isid.ham.common.model.Mbj22CategoryContentVO;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * マスタメンテナンスチェック用DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/11 森)<BR>
 * </P>
 * @author 森
 */
public class MasterMaintenanceCheckDao extends AbstractRdbDao
{
    /** 対象データ */
    private List<Mbj04KeiretsuVO> _voSeries;
    private List<Mbj26BillGroupVO> _voDemandGroup;
    private List<Mbj06HcBumonVO> _voHCSection;
    private List<Mbj22CategoryContentVO> _voCarCategoryContent;
    private List<Mbj29SetteiKykVO> _voEstablishmentOffice;
    private List<Mbj30InputTntVO> _voInputUser;

    /**
     * デフォルトコンストラクタ
     */
    public MasterMaintenanceCheckDao()
    {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを返します
     *
     * @return String[] プライマリキー
     */
    @Override
    public String[] getPrimryKeyNames()
    {
        return null;
    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames()
    {
        return null;
    }

    /**
     * テーブル名を返します
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName()
    {
        return null;
    }

    /**
     * 更新日付フィールドを返します
     *
     * @return String 更新日付フィールド
     */
    @Override
    public String getTimeStampKeyName()
    {
        return null;
    }

    /**
     * SQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL()
    {
        String sql = "";

        if (super.getModel() instanceof Mbj04KeiretsuVO)
        {
            // 系列削除チェック用SQL取得
            sql = getSelectSQLCheckDeleteSeries();
        }
        else if (super.getModel() instanceof Mbj26BillGroupVO)
        {
            // 請求先グループ削除チェック用SQL取得
            sql = getSelectSQLCheckDeleteDemandGroup();
        }
        else if (super.getModel() instanceof Mbj06HcBumonVO)
        {
            // HC部門削除チェック用SQL取得
            sql = getSelectSQLCheckDeleteHCSection();
        }
        else if (super.getModel() instanceof Mbj29SetteiKykVO)
        {
            // 設定局削除チェック用SQL取得
            sql = getSelectSQLCheckDeleteEstablishmentOffice();
        }
        else if (super.getModel() instanceof Mbj30InputTntVO)
        {
            // 入力担当削除チェック用SQL取得
            sql = getSelectSQLCheckDeleteInputUser();
        }
        else if (super.getModel() instanceof Mbj22CategoryContentVO)
        {
            // 車種→カテゴリ登録チェック用SQL取得
            sql = getSelectSQLCheckRegistCarCategoryContent();
        }

        return sql;
    }

    /**
     * 系列削除チェック用のSQL文を返します
     *
     * @return String SQL文
     */
    private String getSelectSQLCheckDeleteSeries()
    {
        StringBuffer selectSql = new StringBuffer();
        StringBuffer sqlWhere = new StringBuffer();

        // 系列コード
        for (int i = 0 ; i < _voSeries.size() ; i++ )
        {
            sqlWhere.append(Mbj05Car.KEIRETSUCD + " = '" + _voSeries.get(i).getKEIRETSUCD() + "' ");

            //最後はＯＲをつけない
            if (i != _voSeries.size() - 1)
            {
                sqlWhere.append(" OR ");
            }
        }

        selectSql.append(String.format("SELECT COUNT(*) AS %s ","DATACOUNT"));
        selectSql.append(String.format("FROM %s ",Mbj05Car.TBNAME));
        selectSql.append(String.format("WHERE (%s) ",sqlWhere.toString()));

        return selectSql.toString();
    }

    /**
     * 請求先グループ削除チェック用のSQL文を返します
     *
     * @return String SQL文
     */
    private String getSelectSQLCheckDeleteDemandGroup()
    {
        StringBuffer selectSql = new StringBuffer();
        StringBuffer sqlWhere = new StringBuffer();

        // フェイズ、設定局ナンバー
        for (int i = 0 ; i < _voDemandGroup.size() ; i++ )
        {
            sqlWhere.append(Tbj11CrCreateData.GROUPCD + " = " + _voDemandGroup.get(i).getGROUPCD().toString() + " ");

            //最後はＯＲをつけない
            if (i != _voDemandGroup.size() - 1)
            {
                sqlWhere.append(" OR ");
            }
        }

        selectSql.append(String.format("SELECT %s.%s AS %s ","D1","CNT","DATACOUNT"));
        selectSql.append(String.format("FROM "));
        selectSql.append(String.format("     ( "));
        selectSql.append(String.format("       SELECT COUNT(*) AS %s ","CNT"));
        selectSql.append(String.format("       FROM %s ",Tbj11CrCreateData.TBNAME));
        selectSql.append(String.format("       WHERE (%s) ",sqlWhere.toString()));
        selectSql.append(String.format("     ) %s ","D1"));

        return selectSql.toString();
    }

    /**
     * HC部門削除チェック用のSQL文を返します
     *
     * @return String SQL文
     */
    private String getSelectSQLCheckDeleteHCSection()
    {
        StringBuffer selectSql = new StringBuffer();
        StringBuffer sqlWhere1 = new StringBuffer();
        StringBuffer sqlWhere2 = new StringBuffer();
        StringBuffer sqlWhere3 = new StringBuffer();

        // HC部門コード、使用部門コード
        for (int i = 0 ; i < _voHCSection.size() ; i++ )
        {
            sqlWhere1.append(Mbj07HcUser.HCBUMONCD + " = '" + _voHCSection.get(i).getHCBUMONCD() + "' ");
            sqlWhere2.append(Mbj26BillGroup.HCBUMONCD + " = '" + _voHCSection.get(i).getHCBUMONCD() + "' ");
            sqlWhere3.append(Mbj08HcProduct.USEBUMONCD + " = '" + _voHCSection.get(i).getUSEBUMONCD() + "' ");

            //最後はＯＲをつけない
            if (i != _voHCSection.size() - 1)
            {
                sqlWhere1.append(" OR ");
                sqlWhere2.append(" OR ");
                sqlWhere3.append(" OR ");
            }
        }

        selectSql.append(String.format("SELECT %s.%s + %s.%s + %s.%s AS %s ","D1","CNT","D2","CNT","D3","CNT","DATACOUNT"));
        selectSql.append(String.format("FROM "));
        selectSql.append(String.format("     ( "));
        selectSql.append(String.format("       SELECT COUNT(*) AS %s ","CNT"));
        selectSql.append(String.format("       FROM %s ",Mbj07HcUser.TBNAME));
        selectSql.append(String.format("       WHERE (%s) ",sqlWhere1.toString()));
        selectSql.append(String.format("     ) %s ","D1"));
        selectSql.append(String.format("    ,( "));
        selectSql.append(String.format("       SELECT COUNT(*) AS %s ","CNT"));
        selectSql.append(String.format("       FROM %s ",Mbj26BillGroup.TBNAME));
        selectSql.append(String.format("       WHERE (%s) ",sqlWhere2.toString()));
        selectSql.append(String.format("     ) %s ","D2"));
        selectSql.append(String.format("    ,( "));
        selectSql.append(String.format("       SELECT COUNT(*) AS %s ","CNT"));
        selectSql.append(String.format("       FROM %s ",Mbj08HcProduct.TBNAME));
        selectSql.append(String.format("       WHERE (%s) ",sqlWhere3.toString()));
        selectSql.append(String.format("     ) %s ","D3"));

        return selectSql.toString();
    }

    /**
     * 設定局削除チェック用のSQL文を返します
     *
     * @return String SQL文
     */
    private String getSelectSQLCheckDeleteEstablishmentOffice()
    {
        StringBuffer selectSql = new StringBuffer();
        StringBuffer sqlWhere1 = new StringBuffer();
        StringBuffer sqlWhere2 = new StringBuffer();
        StringBuffer sqlWhere3 = new StringBuffer();

        // フェイズ、設定局ナンバー
        for (int i = 0 ; i < _voEstablishmentOffice.size() ; i++ )
        {
            sqlWhere1.append("(" + Tbj07EstimateCreate.PHASE + " = " + _voEstablishmentOffice.get(i).getPHASE().toString() + " AND ");
            sqlWhere1.append(Tbj07EstimateCreate.STKYKNO + " = " + _voEstablishmentOffice.get(i).getSTKYKNO().toString() + ") ");
            sqlWhere2.append("(" + Tbj11CrCreateData.PHASE + " = " + _voEstablishmentOffice.get(i).getPHASE().toString() + " AND ");
            sqlWhere2.append(Tbj11CrCreateData.STKYKNO + " = " + _voEstablishmentOffice.get(i).getSTKYKNO().toString() + ") ");
            sqlWhere3.append("(" + Tbj22SeisakuhiSs.PHASE + " = " + _voEstablishmentOffice.get(i).getPHASE().toString() + " AND ");
            sqlWhere3.append(Tbj22SeisakuhiSs.STKYKNO + " = " + _voEstablishmentOffice.get(i).getSTKYKNO().toString() + ") ");

            //最後はＯＲをつけない
            if (i != _voEstablishmentOffice.size() - 1)
            {
                sqlWhere1.append(" OR ");
                sqlWhere2.append(" OR ");
                sqlWhere3.append(" OR ");
            }
        }

        selectSql.append(String.format("SELECT %s.%s + %s.%s + %s.%s AS %s ","D1","CNT","D2","CNT","D3","CNT","DATACOUNT"));
        selectSql.append(String.format("FROM "));
        selectSql.append(String.format("     ( "));
        selectSql.append(String.format("       SELECT COUNT(*) AS %s ","CNT"));
        selectSql.append(String.format("       FROM %s ",Tbj07EstimateCreate.TBNAME));
        selectSql.append(String.format("       WHERE (%s) ",sqlWhere1.toString()));
        selectSql.append(String.format("     ) %s ","D1"));
        selectSql.append(String.format("    ,( "));
        selectSql.append(String.format("       SELECT COUNT(*) AS %s ","CNT"));
        selectSql.append(String.format("       FROM %s ",Tbj11CrCreateData.TBNAME));
        selectSql.append(String.format("       WHERE (%s) ",sqlWhere2.toString()));
        selectSql.append(String.format("     ) %s ","D2"));
        selectSql.append(String.format("    ,( "));
        selectSql.append(String.format("       SELECT COUNT(*) AS %s ","CNT"));
        selectSql.append(String.format("       FROM %s ",Tbj22SeisakuhiSs.TBNAME));
        selectSql.append(String.format("       WHERE (%s) ",sqlWhere3.toString()));
        selectSql.append(String.format("     ) %s ","D3"));

        return selectSql.toString();
    }

    /**
     * 入力担当削除チェック用のSQL文を返します
     *
     * @return String SQL文
     */
    private String getSelectSQLCheckDeleteInputUser()
    {
        final String CLASSDIV_GENKA = "0";   // 制作原価表

        StringBuffer selectSql = new StringBuffer();
        StringBuffer sqlWhere1 = new StringBuffer();
        StringBuffer sqlWhere2 = new StringBuffer();
        StringBuffer sqlWhere3 = new StringBuffer();

        // フェイズ、SeqNo、種別判断フラグ
        for (int i = 0 ; i < _voInputUser.size() ; i++ )
        {
            sqlWhere1.append("(" + Tbj07EstimateCreate.PHASE + " = " + _voInputUser.get(i).getPHASE().toString() + " AND ");
            sqlWhere1.append(Tbj07EstimateCreate.INPUTTNTCD + " = " + _voInputUser.get(i).getSEQNO().toString() + " AND ");
            sqlWhere1.append(Tbj07EstimateCreate.CLASSDIV + " = " + _voInputUser.get(i).getCLASSDIV().toString() + ") ");
            sqlWhere2.append("(" + Tbj11CrCreateData.PHASE + " = " + _voInputUser.get(i).getPHASE().toString() + " AND ");
            sqlWhere2.append(Tbj11CrCreateData.INPUTTNTCD + " = " + _voInputUser.get(i).getSEQNO().toString() + " AND ");
            sqlWhere2.append(Tbj11CrCreateData.CLASSDIV + " = " + _voInputUser.get(i).getCLASSDIV().toString() + ") ");
            if (_voInputUser.get(i).getCLASSDIV().equals(CLASSDIV_GENKA))
            {   // 制作原価表の場合のみ「Tbj22SeisakuhiSs」をチェックする
                sqlWhere3.append("(" + Tbj22SeisakuhiSs.PHASE + " = " + _voInputUser.get(i).getPHASE().toString() + " AND ");
                sqlWhere3.append(Tbj22SeisakuhiSs.INPUTTNTCD + " = " + _voInputUser.get(i).getSEQNO().toString() + " AND ");
                sqlWhere3.append(Tbj22SeisakuhiSs.CLASSDIV + " = " + _voInputUser.get(i).getCLASSDIV().toString() + ") ");
            }

            //最後はＯＲをつけない
            if (i != _voInputUser.size() - 1)
            {
                sqlWhere1.append(" OR ");
                sqlWhere2.append(" OR ");
                if (sqlWhere3.length() > 0)
                {   // sqlWhere3に文字列が設定されている
                    sqlWhere3.append(" OR ");

                }
            }
        }

        if (sqlWhere3.length() > 0)
        {   // sqlWhere3に文字列が設定されている
            selectSql.append(String.format("SELECT %s.%s + %s.%s + %s.%s AS %s ","D1","CNT","D2","CNT","D3","CNT","DATACOUNT"));
        }
        else
        {
            selectSql.append(String.format("SELECT %s.%s + %s.%s AS %s ","D1","CNT","D2","CNT","DATACOUNT"));
        }
        selectSql.append(String.format("FROM "));
        selectSql.append(String.format("     ( "));
        selectSql.append(String.format("       SELECT COUNT(*) AS %s ","CNT"));
        selectSql.append(String.format("       FROM %s ",Tbj07EstimateCreate.TBNAME));
        selectSql.append(String.format("       WHERE (%s) ",sqlWhere1.toString()));
        selectSql.append(String.format("     ) %s ","D1"));
        selectSql.append(String.format("    ,( "));
        selectSql.append(String.format("       SELECT COUNT(*) AS %s ","CNT"));
        selectSql.append(String.format("       FROM %s ",Tbj11CrCreateData.TBNAME));
        selectSql.append(String.format("       WHERE (%s) ",sqlWhere2.toString()));
        selectSql.append(String.format("     ) %s ","D2"));
        if (sqlWhere3.length() > 0)
        {   // sqlWhere3に文字列が設定されている
            selectSql.append(String.format("    ,( "));
            selectSql.append(String.format("       SELECT COUNT(*) AS %s ","CNT"));
            selectSql.append(String.format("       FROM %s ",Tbj22SeisakuhiSs.TBNAME));
            selectSql.append(String.format("       WHERE (%s) ",sqlWhere3.toString()));
            selectSql.append(String.format("     ) %s ","D3"));
        }

        return selectSql.toString();
    }

    /**
     * 車種→カテゴリ登録チェック用のSQL文を返します
     *
     * @return String SQL文
     */
    private String getSelectSQLCheckRegistCarCategoryContent()
    {
        StringBuffer selectSql = new StringBuffer();
        StringBuffer sqlWhere = new StringBuffer();

        // フェイズ
        for (int i = 0 ; i < _voCarCategoryContent.size() ; i++ )
        {
            sqlWhere.append("( ");
            sqlWhere.append(Mbj20CarCategory.PHASE + " = " + _voCarCategoryContent.get(i).getPHASE().toString() + " AND ");
            sqlWhere.append(Mbj20CarCategory.CATEGORYNO + " = " + _voCarCategoryContent.get(i).getCATEGORYNO().toString() + " ");
            sqlWhere.append(") ");

            //最後はＯＲをつけない
            if (i != _voCarCategoryContent.size() - 1)
            {
                sqlWhere.append(" OR ");
            }
        }

        selectSql.append(String.format("SELECT %s.%s AS %s ","D1","CNT","DATACOUNT"));
        selectSql.append(String.format("FROM "));
        selectSql.append(String.format("     ( "));
        selectSql.append(String.format("       SELECT COUNT(*) AS %s ","CNT"));
        selectSql.append(String.format("       FROM %s ",Mbj20CarCategory.TBNAME));
        selectSql.append(String.format("       WHERE (%s) ",sqlWhere.toString()));
        selectSql.append(String.format("     ) %s ","D1"));

        return selectSql.toString();
    }

    /**
     * 系列削除チェックを行います
     *
     * @return チェック結果
     * @param vo 削除対象データ
     * @throws HAMException データアクセス中にエラーが発生した場合（削除不可時も含）
     */
    @SuppressWarnings("unchecked")
    public void  checkDeleteMasterMaintenanceSeries(List<Mbj04KeiretsuVO> vo) throws HAMException
    {
        super.setModel(new Mbj04KeiretsuVO());
        List<CheckRegistMasterMaintenanceVO> result = null;

        try
        {
            _voSeries = vo;
            result = super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(),"BJ-E0001");
        }

        if ((result.size() > 0) && (result.get(0).getDATACOUNT().intValue() > 0))
        {
            throw new HAMException("削除不可","BJ-W0150");
        }

    }

    /**
     * 請求先グループ削除チェックを行います
     *
     * @return チェック結果
     * @param vo 削除対象データ
     * @throws HAMException データアクセス中にエラーが発生した場合（削除不可時も含）
     */
    @SuppressWarnings("unchecked")
    public void  checkDeleteMasterMaintenanceDemandGroup(List<Mbj26BillGroupVO> vo) throws HAMException
    {
        super.setModel(new Mbj26BillGroupVO());
        List<CheckRegistMasterMaintenanceVO> result = null;

        try
        {
            _voDemandGroup = vo;
            result = super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(),"BJ-E0001");
        }

        if ((result.size() > 0) && (result.get(0).getDATACOUNT().intValue() > 0))
        {
            throw new HAMException("削除不可","BJ-W0120");
        }

    }

    /**
     * HC部門削除チェックを行います
     *
     * @return チェック結果
     * @param vo 削除対象データ
     * @throws HAMException データアクセス中にエラーが発生した場合（削除不可時も含）
     */
    @SuppressWarnings("unchecked")
    public void  checkDeleteMasterMaintenanceHCSection(List<Mbj06HcBumonVO> vo) throws HAMException
    {
        super.setModel(new Mbj06HcBumonVO());
        List<CheckRegistMasterMaintenanceVO> result = null;

        try
        {
            _voHCSection = vo;
            result = super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(),"BJ-E0001");
        }

        if ((result.size() > 0) && (result.get(0).getDATACOUNT().intValue() > 0))
        {
            throw new HAMException("削除不可","BJ-W0117");
        }

    }

    /**
     * 設定局削除チェックを行います
     *
     * @return チェック結果
     * @param vo 削除対象データ
     * @throws HAMException データアクセス中にエラーが発生した場合（削除不可時も含）
     */
    @SuppressWarnings("unchecked")
    public void  checkDeleteMasterMaintenanceEstablishmentOffice(List<Mbj29SetteiKykVO> vo) throws HAMException
    {
        super.setModel(new Mbj29SetteiKykVO());
        List<CheckRegistMasterMaintenanceVO> result = null;

        try
        {
            _voEstablishmentOffice = vo;
            result = super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(),"BJ-E0001");
        }

        if ((result.size() > 0) && (result.get(0).getDATACOUNT().intValue() > 0))
        {
            throw new HAMException("削除不可","BJ-W0046");
        }

    }

    /**
     * 入力担当削除チェックを行います
     *
     * @return チェック結果
     * @param vo 削除対象データ
     * @throws HAMException データアクセス中にエラーが発生した場合（削除不可時も含）
     */
    @SuppressWarnings("unchecked")
    public void  checkDeleteMasterMaintenanceInputUser(List<Mbj30InputTntVO> vo) throws HAMException
    {
        super.setModel(new Mbj30InputTntVO());
        List<CheckRegistMasterMaintenanceVO> result = null;

        try
        {
            _voInputUser = vo;
            result = super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(),"BJ-E0001");
        }

        if ((result.size() > 0) && (result.get(0).getDATACOUNT().intValue() > 0))
        {
            throw new HAMException("削除不可","BJ-W0047");
        }

    }

    /**
     * 車種→カテゴリ登録チェックを行います
     *
     * @return チェック結果
     * @param vo 登録対象データ
     * @throws HAMException データアクセス中にエラーが発生した場合（登録不可時も含）
     */
    @SuppressWarnings("unchecked")
    public void  checkRegistMasterMaintenanceCarCategoryContent(List<Mbj22CategoryContentVO> vo) throws HAMException
    {
        super.setModel(new Mbj22CategoryContentVO());
        List<CheckRegistMasterMaintenanceVO> result = null;

        try
        {
            _voCarCategoryContent = vo;
            result = super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(),"BJ-E0001");
        }

        if ((result.size() > 0) && (result.get(0).getDATACOUNT().intValue() == 0))
        {
            throw new HAMException("登録不可","BJ-W0173");
        }

    }

    /**
     * Modelの生成を行う<br>
     * AbstractRdbDaoのcreateFindedModelInstancesをオーバーライド<br>
     *
     * @param hashList List 検索結果
     * @return List 変換後の検索結果
     */
    @SuppressWarnings("unchecked")
    @Override
    protected List createFindedModelInstances(List hashList)
    {
        List list = null;

        list = new ArrayList<CheckRegistMasterMaintenanceVO>();
        for (int i = 0; i < hashList.size(); i++)
        {
            Map result = (Map) hashList.get(i);
            CheckRegistMasterMaintenanceVO vo = new CheckRegistMasterMaintenanceVO();

            vo.setDATACOUNT((BigDecimal)result.get("DATACOUNT"));

            list.add(vo);
        }

        return list;
    }

}
