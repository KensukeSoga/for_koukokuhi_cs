package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj05EstimateItem;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 見積案件DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * ・請求業務変更対応(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj05EstimateItemDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj05EstimateItemCondition _condition = null;

    /** 登録データ */
    private Tbj05EstimateItemVO _vo = null;

    /** SQLモード */
    private enum SqlMode { Insert, Update, Delete, UpdateOutput }

    private SqlMode _sqlMode = null;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj05EstimateItemDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを取得する
     *
     * @return String[] プライマリキー
     */
    public String[] getPrimryKeyNames() {
        return new String[] {
                Tbj05EstimateItem.PHASE
                ,Tbj05EstimateItem.CRDATE
                ,Tbj05EstimateItem.ESTSEQNO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj05EstimateItem.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        if (_sqlMode.equals(SqlMode.Insert)) {
            return new String[] {
                    Tbj05EstimateItem.CRTDATE
                    ,Tbj05EstimateItem.UPDDATE
            };
        } else {
            return new String[] {
                    Tbj05EstimateItem.UPDDATE
            };
        }
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj05EstimateItem.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj05EstimateItem.PHASE
                ,Tbj05EstimateItem.CRDATE
                ,Tbj05EstimateItem.ESTSEQNO
                ,Tbj05EstimateItem.ESTIMATECLASS
                ,Tbj05EstimateItem.ESTIMATEDATE
                ,Tbj05EstimateItem.COOPKBN
                ,Tbj05EstimateItem.ADDRESS
                ,Tbj05EstimateItem.ESTIMATENM
                ,Tbj05EstimateItem.HCBUMONCD
                ,Tbj05EstimateItem.HCUSERNM
                ,Tbj05EstimateItem.DLVDATE
                ,Tbj05EstimateItem.DISCOUNTRATE
                ,Tbj05EstimateItem.BIKO
                ,Tbj05EstimateItem.LASTOUTPUTDATE
                ,Tbj05EstimateItem.LASTOUTPUTNM
                ,Tbj05EstimateItem.OUTPUTFILENM
                ,Tbj05EstimateItem.DCARCD
                ,Tbj05EstimateItem.DIVCD
                ,Tbj05EstimateItem.GROUPCD
                ,Tbj05EstimateItem.BILLDTLLASTOUTPUTDATE
                ,Tbj05EstimateItem.BILLDTLLASTOUTPUTNM
                ,Tbj05EstimateItem.BILLDTLOUTPUTFILENM
                ,Tbj05EstimateItem.BILLLASTOUTPUTDATE
                ,Tbj05EstimateItem.BILLLASTOUTPUTNM
                ,Tbj05EstimateItem.BILLOUTPUTFILENM
                ,Tbj05EstimateItem.BILLEXLLASTOUTPUTDATE
                ,Tbj05EstimateItem.BILLEXLLASTOUTPUTNM
                ,Tbj05EstimateItem.BILLEXLOUTPUTFILENM
                ,Tbj05EstimateItem.CRTDATE
                ,Tbj05EstimateItem.CRTNM
                ,Tbj05EstimateItem.CRTAPL
                ,Tbj05EstimateItem.CRTID
                ,Tbj05EstimateItem.UPDDATE
                ,Tbj05EstimateItem.UPDNM
                ,Tbj05EstimateItem.UPDAPL
                ,Tbj05EstimateItem.UPDID
        };
    }

    /**
     * AbstractModelの値の設定有無からSQLのWHERE句を生成する
     * @param vo
     * @return
     */
    private String generateWhereByCond(AbstractModel vo) {
        StringBuffer sql = new StringBuffer();

        for (int i = 0; i < getTableColumnNames().length; i++) {

            Object value = vo.get(getTableColumnNames()[i]);

            if (value != null) {
                if (sql.length() == 0) {
                    sql.append(" WHERE ");
                } else {
                    sql.append(" AND ");
                }

                sql.append(getTableColumnNames()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
            }
        }

        return sql.toString();
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {

        String sql = "";

        if (super.getModel() instanceof Tbj05EstimateItemVO) {

            //Tbj05EstimateItemVO取得用SQL取得
            sql = getSelectSQLTbj05EstimateItemVO();
        }

        return sql;
    }

    /**
     * SELECT SQL(Tbj05EstimateItemVO)
     */
    private String getSelectSQLTbj05EstimateItemVO() {

        StringBuffer selectSql = new StringBuffer();
        String whereSqlStr = "";

        //*******************************************
        //load()、find()で使用されるSELECT + FROM句のSQL
        //*******************************************
        selectSql.append(" SELECT ");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            selectSql.append((i != 0 ? " ," : " "));
            selectSql.append(getTableColumnNames()[i] + " ");
        }

        selectSql.append(" FROM ");
        selectSql.append(" " + getTableName() + " ");

        if (_condition != null) {

            Tbj05EstimateItemVO vo = new Tbj05EstimateItemVO();

            vo.setPHASE(_condition.getPhase());
            vo.setCRDATE(_condition.getCrdate());
            vo.setESTSEQNO(_condition.getEstseqno());
            vo.setESTIMATECLASS(_condition.getEstimateclass());
            vo.setESTIMATEDATE(_condition.getEstimatedate());
            vo.setCOOPKBN(_condition.getCoopkbn());
            vo.setADDRESS(_condition.getAddress());
            vo.setESTIMATENM(_condition.getEstimatenm());
            vo.setHCBUMONCD(_condition.getHcbumoncd());
            vo.setHCUSERNM(_condition.getHcusernm());
            vo.setDLVDATE(_condition.getDlvdate());
            vo.setDISCOUNTRATE(_condition.getDiscountrate());
            vo.setBIKO(_condition.getBiko());
            vo.setLASTOUTPUTDATE(_condition.getLastoutputdate());
            vo.setLASTOUTPUTNM(_condition.getLastoutputnm());
            vo.setOUTPUTFILENM(_condition.getOutputfilenm());
            vo.setDCARCD(_condition.getDcarcd());
            vo.setDIVCD(_condition.getDivcd());
            vo.setGROUPCD(_condition.getGroupcd());
            vo.setBILLDTLLASTOUTPUTDATE(_condition.getBilldtllastoutputdate());
            vo.setBILLDTLLASTOUTPUTNM(_condition.getBilldtllastoutputnm());
            vo.setBILLDTLOUTPUTFILENM(_condition.getBilldtloutputfilenm());
            vo.setBILLLASTOUTPUTDATE(_condition.getBilllastoutputdate());
            vo.setBILLLASTOUTPUTNM(_condition.getBilllastoutputnm());
            vo.setBILLOUTPUTFILENM(_condition.getBilloutputfilenm());
            vo.setBILLEXLLASTOUTPUTDATE(_condition.getBillexllastoutputdate());
            vo.setBILLEXLLASTOUTPUTNM(_condition.getBillexllastoutputnm());
            vo.setBILLEXLOUTPUTFILENM(_condition.getBillexloutputfilenm());
            vo.setCRTDATE(_condition.getCrtdate());
            vo.setCRTNM(_condition.getCrtnm());
            vo.setCRTAPL(_condition.getCrtapl());
            vo.setCRTID(_condition.getCrtid());
            vo.setUPDDATE(_condition.getUpddate());
            vo.setUPDNM(_condition.getUpdnm());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDID(_condition.getUpdid());

            whereSqlStr = generateWhereByCond(vo);
        }

        return selectSql.toString() + whereSqlStr;
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getExecString() {

        StringBuffer sql = new StringBuffer();

        //削除
        if (_sqlMode.equals(SqlMode.Delete)) {

            sql.append(" DELETE FROM");
            sql.append(" " + Tbj05EstimateItem.TBNAME);
            sql.append(" WHERE");
            sql.append(" " + Tbj05EstimateItem.PHASE + " = " + _condition.getPhase() + " AND");
            sql.append(" " + Tbj05EstimateItem.CRDATE + " = " + getDBModelInterface().ConvertToDBString(_condition.getCrdate()) + " AND");
            sql.append(" " + Tbj05EstimateItem.ESTSEQNO + " = " + _condition.getEstseqno());
        }
        //見積書・請求明細書・請求書・請求Excelデータ出力
        else if (_sqlMode.equals(SqlMode.UpdateOutput)) {

            sql.append(" UPDATE");
            sql.append(" " + Tbj05EstimateItem.TBNAME);

            sql.append(" SET");

            /* 2015/08/31 請求業務変更対応 HLC S.Fujimoto MOD Start */
            //見積書
            if (_vo.getLASTOUTPUTDATE() != null) {
                sql.append(" " + Tbj05EstimateItem.LASTOUTPUTDATE + " = " + getDBModelInterface().ConvertToDBString(_vo.getLASTOUTPUTDATE()) + ",");
                sql.append(" " + Tbj05EstimateItem.LASTOUTPUTNM + " = '" + _vo.getLASTOUTPUTNM() + "',");
                sql.append(" " + Tbj05EstimateItem.OUTPUTFILENM + " = '" + _vo.getOUTPUTFILENM() + "',");
            }
            //請求明細書
            if (_vo.getBILLDTLLASTOUTPUTDATE() != null) {
                sql.append(" " + Tbj05EstimateItem.BILLDTLLASTOUTPUTDATE + " = " + getDBModelInterface().ConvertToDBString(_vo.getBILLDTLLASTOUTPUTDATE()) + ",");
                sql.append(" " + Tbj05EstimateItem.BILLDTLLASTOUTPUTNM + " = '" + _vo.getBILLDTLLASTOUTPUTNM() + "',");
                sql.append(" " + Tbj05EstimateItem.BILLDTLOUTPUTFILENM + " = '" + _vo.getBILLDTLOUTPUTFILENM() + "',");
            }
            //請求書
            if (_vo.getBILLLASTOUTPUTDATE() != null) {
                sql.append(" " + Tbj05EstimateItem.BILLLASTOUTPUTDATE + " = " + getDBModelInterface().ConvertToDBString(_vo.getBILLLASTOUTPUTDATE()) + ",");
                sql.append(" " + Tbj05EstimateItem.BILLLASTOUTPUTNM + " = '" + _vo.getBILLLASTOUTPUTNM() + "',");
                sql.append(" " + Tbj05EstimateItem.BILLOUTPUTFILENM + " = '" + _vo.getBILLOUTPUTFILENM() + "',");
            }
            //請求Excelデータ
            if (_vo.getBILLEXLLASTOUTPUTDATE() != null) {
                sql.append(" " + Tbj05EstimateItem.BILLEXLLASTOUTPUTDATE + " = " + getDBModelInterface().ConvertToDBString(_vo.getBILLEXLLASTOUTPUTDATE()) + ",");
                sql.append(" " + Tbj05EstimateItem.BILLEXLLASTOUTPUTNM + " = '" + _vo.getBILLEXLLASTOUTPUTNM() + "',");
                sql.append(" " + Tbj05EstimateItem.BILLEXLOUTPUTFILENM + " = '" + _vo.getBILLEXLOUTPUTFILENM() + "',");
            }
            /* 2015/08/31 請求業務変更対応 HLC S.Fujimoto MOD End */

            //sql.append(" " + Tbj05EstimateItem.UPDDATE + " = " + "SYSDATE,");
            sql.append(" " + Tbj05EstimateItem.UPDNM + " = '" + _vo.getUPDNM() + "',");
            sql.append(" " + Tbj05EstimateItem.UPDAPL + " = '" + _vo.getUPDAPL() + "',");
            sql.append(" " + Tbj05EstimateItem.UPDID + " = '" + _vo.getUPDID() + "'");

            sql.append(" WHERE");
            sql.append(" " + Tbj05EstimateItem.PHASE + " = " + _vo.getPHASE() + " AND");
            sql.append(" " + Tbj05EstimateItem.CRDATE + " = " + getDBModelInterface().ConvertToDBString(_vo.getCRDATE()) + " AND");
            sql.append(" " + Tbj05EstimateItem.ESTSEQNO + " = " + _vo.getESTSEQNO());
        }

        return sql.toString();
    }

    /**
     * 見積案件を削除します
     * @param condition 削除条件
     * @throws HAMException
     */
    public void deleteEstimateItem(Tbj05EstimateItemCondition condition) throws HAMException {

        try {
            _condition = condition;
            _sqlMode = SqlMode.Delete;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * UpdateVO
     * @param vo データ
     * @throws HAMException
     */
    public void updateVO(Tbj05EstimateItemVO vo) throws HAMException {

        // パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);

        try {
            _sqlMode = SqlMode.Update;
            if (!super.update()) {
                throw new HAMException("更新エラー", "BJ-E0003");
            }
        }
        catch(UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }

    }

    /**
     * InsertVO
     * @param vo データ
     * @throws HAMException
     */
    public void insertVO(Tbj05EstimateItemVO vo) throws HAMException {

        // パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);

        try {
            _sqlMode = SqlMode.Insert;
            if (!super.insert()) {
                throw new HAMException("登録エラー", "BJ-E0002");
            }
        }
        catch(UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }

    }

    /**
     * 見積帳票出力情報を更新する
     * @param vo 更新データ
     * @throws HAMException
     */
    public void updateOutputInfo(Tbj05EstimateItemVO vo) throws HAMException {

        //パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);

        try {
            _vo = vo;
            _sqlMode = SqlMode.UpdateOutput;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * SelectVO
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj05EstimateItemVO> selectVO(Tbj05EstimateItemCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj05EstimateItemVO());
        _condition = condition;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
