package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 見積明細DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj06EstimateDetailDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj06EstimateDetailCondition _condition = null;

    /** SQLのモード() */
    private enum SelSqlMode {Insert, Update, Delete, FIND, BILLSEQNO}

    private SelSqlMode _SelSqlMode = null;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj06EstimateDetailDAO() {
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
                Tbj06EstimateDetail.ESTDETAILSEQNO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj06EstimateDetail.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        if (_SelSqlMode.equals(SelSqlMode.Insert)) {
            return new String[] {
                    Tbj06EstimateDetail.CRTDATE
                    ,Tbj06EstimateDetail.UPDDATE
            };
        } else {
            return new String[] {
                    Tbj06EstimateDetail.UPDDATE
            };
        }
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj06EstimateDetail.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj06EstimateDetail.ESTDETAILSEQNO
                ,Tbj06EstimateDetail.PHASE
                ,Tbj06EstimateDetail.CRDATE
                ,Tbj06EstimateDetail.ESTSEQNO
                ,Tbj06EstimateDetail.SORTNO
                ,Tbj06EstimateDetail.PRODUCTCD
                ,Tbj06EstimateDetail.PRODUCTNM
                ,Tbj06EstimateDetail.PRODUCTNMSUB
                ,Tbj06EstimateDetail.MEDIACLASSCD
                ,Tbj06EstimateDetail.MEDIACD
                ,Tbj06EstimateDetail.BUSINESSCLASSCD
                ,Tbj06EstimateDetail.BUSINESSCD
                ,Tbj06EstimateDetail.TEKIYOU
                ,Tbj06EstimateDetail.OPERATIONDATE
                ,Tbj06EstimateDetail.SIZECD
                ,Tbj06EstimateDetail.SIZE
                ,Tbj06EstimateDetail.SUURYOU
                ,Tbj06EstimateDetail.UNITGROUPCD
                ,Tbj06EstimateDetail.UNITGROUPNM
                ,Tbj06EstimateDetail.TANKA
                ,Tbj06EstimateDetail.HYOUJUN
                ,Tbj06EstimateDetail.NEBIKI
                ,Tbj06EstimateDetail.MITUMORI
                ,Tbj06EstimateDetail.KAZEI
                ,Tbj06EstimateDetail.SYOUHIZEI
                ,Tbj06EstimateDetail.GOUKEI
                ,Tbj06EstimateDetail.CALKBN
                ,Tbj06EstimateDetail.NOUNYUUFLG
                ,Tbj06EstimateDetail.DEKIDAKAFLG
                ,Tbj06EstimateDetail.OUTPUTGROUP
                ,Tbj06EstimateDetail.HCBUMONCDBILL
                ,Tbj06EstimateDetail.HCBUMONCDBILLSEQNO
                ,Tbj06EstimateDetail.CRTDATE
                ,Tbj06EstimateDetail.CRTNM
                ,Tbj06EstimateDetail.CRTAPL
                ,Tbj06EstimateDetail.CRTID
                ,Tbj06EstimateDetail.UPDDATE
                ,Tbj06EstimateDetail.UPDNM
                ,Tbj06EstimateDetail.UPDAPL
                ,Tbj06EstimateDetail.UPDID
        };
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {

        String sql = "";

        if (super.getModel() instanceof Tbj06EstimateDetailVO) {
            //Tbj06EstimateDetailVO取得用SQL取得
            sql = getSelectSQLTbj06EstimateDetailVO();
        }

        return sql;
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
     * SELECT SQL(Tbj06EstimateDetailVO)
     */
    private String getSelectSQLTbj06EstimateDetailVO() {

        StringBuffer selectSql = new StringBuffer();
        String whereSqlStr = "";
        StringBuffer orderSql = new StringBuffer();
        StringBuffer sql = new StringBuffer();

        if(_SelSqlMode.equals(SelSqlMode.BILLSEQNO)){
            sql.append(" SELECT");
            sql.append(" " + Tbj06EstimateDetail.ESTDETAILSEQNO + ",");
            sql.append(" " + Tbj06EstimateDetail.PHASE + ",");
            sql.append(" " + Tbj06EstimateDetail.CRDATE + ",");
            sql.append(" " + Tbj06EstimateDetail.ESTSEQNO + ",");
            sql.append(" " + Tbj06EstimateDetail.SORTNO + ",");
            sql.append(" " + Tbj06EstimateDetail.PRODUCTCD + ",");
            sql.append(" " + Tbj06EstimateDetail.PRODUCTNM + ",");
            sql.append(" " + Tbj06EstimateDetail.PRODUCTNMSUB + ",");
            sql.append(" " + Tbj06EstimateDetail.MEDIACLASSCD + ",");
            sql.append(" " + Tbj06EstimateDetail.MEDIACD + ",");
            sql.append(" " + Tbj06EstimateDetail.BUSINESSCLASSCD + ",");
            sql.append(" " + Tbj06EstimateDetail.BUSINESSCD + ",");
            sql.append(" " + Tbj06EstimateDetail.TEKIYOU + ",");
            sql.append(" " + Tbj06EstimateDetail.OPERATIONDATE + ",");
            sql.append(" " + Tbj06EstimateDetail.SIZECD + ",");
            sql.append(" " + Tbj06EstimateDetail.SIZE + ",");
            sql.append(" " + Tbj06EstimateDetail.SUURYOU + ",");
            sql.append(" " + Tbj06EstimateDetail.UNITGROUPCD + ",");
            sql.append(" " + Tbj06EstimateDetail.UNITGROUPNM + ",");
            sql.append(" " + Tbj06EstimateDetail.TANKA + ",");
            sql.append(" " + Tbj06EstimateDetail.HYOUJUN + ",");
            sql.append(" " + Tbj06EstimateDetail.NEBIKI + ",");
            sql.append(" " + Tbj06EstimateDetail.MITUMORI + ",");
            sql.append(" " + Tbj06EstimateDetail.KAZEI + ",");
            sql.append(" " + Tbj06EstimateDetail.SYOUHIZEI + ",");
            sql.append(" " + Tbj06EstimateDetail.GOUKEI + ",");
            sql.append(" " + Tbj06EstimateDetail.CALKBN + ",");
            sql.append(" " + Tbj06EstimateDetail.NOUNYUUFLG + ",");
            sql.append(" " + Tbj06EstimateDetail.DEKIDAKAFLG + ",");
            sql.append(" " + Tbj06EstimateDetail.OUTPUTGROUP + ",");
            sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILL + ",");
            sql.append(" " + Tbj06EstimateDetail.HCBUMONCDBILLSEQNO + ",");
            sql.append(" " + Tbj06EstimateDetail.CRTDATE + ",");
            sql.append(" " + Tbj06EstimateDetail.CRTNM + ",");
            sql.append(" " + Tbj06EstimateDetail.CRTAPL + ",");
            sql.append(" " + Tbj06EstimateDetail.CRTID + ",");
            sql.append(" " + Tbj06EstimateDetail.UPDDATE + ",");
            sql.append(" " + Tbj06EstimateDetail.UPDNM + ",");
            sql.append(" " + Tbj06EstimateDetail.UPDAPL + ",");
            sql.append(" " + Tbj06EstimateDetail.UPDID);


            sql.append(" FROM");
            sql.append(" " + Tbj06EstimateDetail.TBNAME);
            sql.append(" WHERE");
            sql.append(" " + Tbj06EstimateDetail.PHASE + " = " + _condition.getPhase() + " AND");
            sql.append(" " + Tbj06EstimateDetail.CRDATE + " = " + getDBModelInterface().ConvertToDBString(_condition.getCrdate()) + " AND");
            sql.append(" " + Tbj06EstimateDetail.ESTSEQNO + " = " + _condition.getEstseqno());
            sql.append(" ORDER BY");
            sql.append(" " + Tbj06EstimateDetail.SORTNO);

            return sql.toString();

        }else{
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

                Tbj06EstimateDetailVO vo = new Tbj06EstimateDetailVO();

                vo.setESTDETAILSEQNO(_condition.getEstdetailseqno());
                vo.setPHASE(_condition.getPhase());
                vo.setCRDATE(_condition.getCrdate());
                vo.setESTSEQNO(_condition.getEstseqno());
                vo.setSORTNO(_condition.getSortno());
                vo.setPRODUCTCD(_condition.getProductcd());
                vo.setPRODUCTNM(_condition.getProductnm());
                vo.setPRODUCTNMSUB(_condition.getProductnmsub());
                vo.setMEDIACLASSCD(_condition.getMediaclasscd());
                vo.setMEDIACD(_condition.getMediacd());
                vo.setBUSINESSCLASSCD(_condition.getBusinessclasscd());
                vo.setBUSINESSCD(_condition.getBusinesscd());
                vo.setTEKIYOU(_condition.getTekiyou());
                vo.setOPERATIONDATE(_condition.getOperationdate());
                vo.setSIZECD(_condition.getSizecd());
                vo.setSIZE(_condition.getSize());
                vo.setSUURYOU(_condition.getSuuryou());
                vo.setUNITGROUPCD(_condition.getUnitgroupcd());
                vo.setUNITGROUPNM(_condition.getUnitgroupnm());
                vo.setTANKA(_condition.getTanka());
                vo.setHYOUJUN(_condition.getHyoujun());
                vo.setNEBIKI(_condition.getNebiki());
                vo.setMITUMORI(_condition.getMitumori());
                vo.setKAZEI(_condition.getKazei());
                vo.setSYOUHIZEI(_condition.getSyouhizei());
                vo.setGOUKEI(_condition.getGoukei());
                vo.setCALKBN(_condition.getCalkbn());
                vo.setNOUNYUUFLG(_condition.getNounyuuflg());
                vo.setDEKIDAKAFLG(_condition.getDekidakaflg());
                vo.setOUTPUTGROUP(_condition.getOutputgroup());
                vo.setHCBUMONCDBILL(_condition.getHcbumoncdbill());
                vo.setHCBUMONCDBILLSEQNO(_condition.getHcbumoncdbillseqno());
                vo.setCRTDATE(_condition.getCrtdate());
                vo.setCRTNM(_condition.getCrtnm());
                vo.setCRTAPL(_condition.getCrtapl());
                vo.setCRTID(_condition.getCrtid());
                vo.setUPDDATE(_condition.getUpddate());
                vo.setUPDNM(_condition.getUpdnm());
                vo.setUPDAPL(_condition.getUpdapl());
                vo.setUPDID(_condition.getUpdid());

                whereSqlStr = generateWhereByCond(vo);
                orderSql.append(" ORDER BY ");
                orderSql.append(" " + Tbj06EstimateDetail.SORTNO + " ");
            }

            return selectSql.toString() + whereSqlStr + orderSql.toString();
        }
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getExecString() {

        StringBuffer sql = new StringBuffer();

        sql.append("DELETE FROM ");
        sql.append(Tbj06EstimateDetail.TBNAME);
        sql.append(" WHERE ");

        if (!_condition.getEstdetailseqno().equals(BigDecimal.valueOf(0))) {
            sql.append(Tbj06EstimateDetail.ESTDETAILSEQNO);
            sql.append(" = ");
            sql.append(_condition.getEstdetailseqno());
        } else {
            sql.append(Tbj06EstimateDetail.PHASE);
            sql.append(" = ");
            sql.append(_condition.getPhase());
            sql.append(" AND ");
            sql.append(Tbj06EstimateDetail.CRDATE);
            sql.append(" = ");
            sql.append(getDBModelInterface().ConvertToDBString(_condition.getCrdate()));
            sql.append(" AND ");
            sql.append(Tbj06EstimateDetail.ESTSEQNO);
            sql.append(" = ");
            sql.append(_condition.getEstseqno());
        }

        return sql.toString();
    }

    /**
     * 見積明細を削除します
     * @param condition 削除条件
     * @throws HAMException
     */
    public void deleteEstimateDetail(Tbj06EstimateDetailCondition condition) throws HAMException {

        try {
            _condition = condition;
            _SelSqlMode = SelSqlMode.Delete;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * InsertVO
     * @param vo データ
     * @throws HAMException
     */
    public void insertVO(Tbj06EstimateDetailVO vo) throws HAMException {

        // パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);

        try {
            _SelSqlMode = SelSqlMode.Insert;

            if (!super.insert()) {
                throw new HAMException("登録エラー", "BJ-E0002");
            }
        } catch(UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }

    }

    /**
     * UpdateVO
     * @param vo データ
     * @throws HAMException
     */
    public void updateVO(Tbj06EstimateDetailVO vo) throws HAMException {
        // パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);

        try {
            _SelSqlMode = SelSqlMode.Update;

            if (!super.update()) {
                throw new HAMException("更新エラー", "BJ-E0003");
            }
        } catch(UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * SelectVO
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj06EstimateDetailVO> selectVO(Tbj06EstimateDetailCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj06EstimateDetailVO());
        _condition = condition;
        _SelSqlMode = SelSqlMode.FIND;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 請求先グループ出力順SEQNO検索用
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj06EstimateDetailVO> findBillSeqNoVO(Tbj06EstimateDetailCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj06EstimateDetailVO());
        _condition = condition;
        _SelSqlMode = SelSqlMode.BILLSEQNO;

        try {
            return (List<Tbj06EstimateDetailVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
