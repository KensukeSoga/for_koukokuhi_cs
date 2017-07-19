package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.ConcurrentUpdateException;
import jp.co.isid.nj.integ.UpdateFailureException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 請求グループマスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * ・請求業務変更対応(2016/02/04 HLC K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj26BillGroupDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Mbj26BillGroupCondition _condition = null;
    /** 請求先グループコード */
    private String _groupCd = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SqlMode { LOAD, VO, IN, BILL, HCBUMONBILL};
    private SqlMode _sqlMode = SqlMode.LOAD;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj26BillGroupDAO() {
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
                Mbj26BillGroup.GROUPCD
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Mbj26BillGroup.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj26BillGroup.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Mbj26BillGroup.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj26BillGroup.GROUPCD
                ,Mbj26BillGroup.GROUPNM
                ,Mbj26BillGroup.GROUPNMRPT
                ,Mbj26BillGroup.SORTNO
                ,Mbj26BillGroup.HCBUMONCD
                ,Mbj26BillGroup.HCBUMONCDBILL
                ,Mbj26BillGroup.UPDDATE
                ,Mbj26BillGroup.UPDNM
                ,Mbj26BillGroup.UPDAPL
                ,Mbj26BillGroup.UPDID
        };
    }

    /**
     * デフォルトのSQL文を返します
     */
    @Override
    public String getSelectSQL() {

        StringBuffer sql = new StringBuffer();
        StringBuffer whereSql = new StringBuffer();
        StringBuffer orderSql = new StringBuffer();

        if (_sqlMode.equals(SqlMode.LOAD)) {

            //*******************************************
            // Load()で使用されるSELECT + FROM句のSQL
            //*******************************************
            sql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                sql.append((i != 0 ? " ," : " "));
                sql.append("" + getTableColumnNames()[i] + " ");
            }

            sql.append(" FROM ");
            sql.append(" " + getTableName() + " ");

        } else if (_sqlMode.equals(SqlMode.VO)) {

            sql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                sql.append((i != 0 ? " ," : " "));
                sql.append("" + getTableColumnNames()[i] + " ");
            }

            sql.append(" FROM ");
            sql.append(" " + getTableName() + " ");

            // WHERE句
            if (_condition != null) {

                Mbj26BillGroupVO vo = new Mbj26BillGroupVO();
                vo.setGROUPCD(_condition.getGroupcd());
                vo.setGROUPNM(_condition.getGroupnm());
                vo.setGROUPNMRPT(_condition.getGroupnmrpt());
                vo.setSORTNO(_condition.getSortno());
                vo.setHCBUMONCD(_condition.getHcbumoncd());
                vo.setHCBUMONCDBILL(_condition.getHcbumoncdbill());
                vo.setUPDDATE(_condition.getUpddate());
                vo.setUPDNM(_condition.getUpdnm());
                vo.setUPDAPL(_condition.getUpdapl());
                vo.setUPDID(_condition.getUpdid());

                whereSql.append(generateWhereByCond(vo));
            }

            orderSql.append(" ORDER BY ");
            orderSql.append(" " + Mbj26BillGroup.SORTNO + "," + Mbj26BillGroup.GROUPCD + " ");

        } else if (_sqlMode.equals(SqlMode.IN)) {

            // SELECT + FROM句
            sql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                sql.append((i != 0 ? " ," : " "));
                sql.append("" + getTableColumnNames()[i] + " ");
            }

            sql.append(" FROM ");
            sql.append(" " + getTableName() + " ");

            whereSql.append(" WHERE ");
            whereSql.append(" " + Mbj26BillGroup.GROUPCD + " IN (" + _groupCd + ") ");

            orderSql.append(" ORDER BY ");
            orderSql.append(" " + Mbj26BillGroup.SORTNO + "," + Mbj26BillGroup.GROUPCD + " ");

        } else if (_sqlMode.equals(SqlMode.BILL)) {

            sql.append(" SELECT");
            sql.append(" " + Mbj26BillGroup.GROUPCD + ",");
            sql.append(" " + Mbj26BillGroup.HCBUMONCDBILL);

            sql.append(" FROM");
            sql.append(" " + Mbj26BillGroup.TBNAME);

            sql.append(" WHERE");

            /* 2016/02/04 請求業務変更対応 HLC K.Soga MOD Start */
//            sql.append(" " + Mbj26BillGroup.HCBUMONCDBILL + " IS NOT NULL");
            //制作
            if(!_groupCd.equals(HAMConstants.GROUPCODE0.toString()))
            {
                sql.append(" " + Mbj26BillGroup.HCBUMONCDBILL + " IS NOT NULL AND");
                sql.append(" " + Mbj26BillGroup.GROUPCD + " = " + _groupCd);
            }
            //媒体
            else
            {
                sql.append(" " + Mbj26BillGroup.HCBUMONCDBILL + " IS NOT NULL");
            }
            /* 2016/02/04 請求業務変更対応 HLC K.Soga MOD End */

            sql.append(" UNION ALL");

            sql.append(" SELECT");
            sql.append(" " + Mbj26BillGroup.GROUPCD + ",");
            sql.append(" '" + HAMConstants.BILLGROUP_UNKNOWN + "'");

            sql.append(" FROM");
            sql.append(" " + Mbj26BillGroup.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Mbj26BillGroup.HCBUMONCDBILL + " IS NULL");

            sql.append(" ORDER BY");
            sql.append(" " + Mbj26BillGroup.HCBUMONCDBILL + ",");
            sql.append(" " + Mbj26BillGroup.GROUPCD);

        } else if (_sqlMode.equals(SqlMode.HCBUMONBILL)) {

            sql.append(" SELECT");
            sql.append(" " + Mbj26BillGroup.HCBUMONCDBILL);

            sql.append(" FROM");
            sql.append(" " + Mbj26BillGroup.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Mbj26BillGroup.GROUPCD + " = " + _groupCd);

            sql.append(" ORDER BY");
            sql.append(" " + Mbj26BillGroup.GROUPCD);
        }

        return sql.toString() + whereSql.toString() + orderSql.toString();
    };

    /**
     * AbstractModelの値の設定有無からSQLのWHERE句を生成する
     *
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
     * InsertVO
     * @param vo データ
     * @throws HAMException
     */
    public void insertVO(Mbj26BillGroupVO vo) throws HAMException
    {
        // パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);

        try {
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
    public void updateVO(Mbj26BillGroupVO vo) throws HAMException
    {
        // パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);

        try {
            if (!super.update()) {
                throw new HAMException("更新エラー", "BJ-E0003");
            }
        } catch(UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * DeleteVO
     * @param vo データ
     * @throws HAMException
     */
    public void deleteVO(Mbj26BillGroupVO vo) throws HAMException
    {
        // パラメータチェック
        if (vo == null) {
            throw new HAMException("削除エラー", "BJ-E0004");
        }
        super.setModel(vo);

        try {
            if (!super.remove()) {
                throw new HAMException("削除エラー", "BJ-E0004");
            }
        } catch(ConcurrentUpdateException e) {
            // 処理件数「0」の場合
            return;
        } catch(UpdateFailureException e) {
            // 処理件数「2以上」の場合
            return;
        } catch(UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj26BillGroupVO> selectVO(Mbj26BillGroupCondition condition) throws HAMException {

        super.setModel(new Mbj26BillGroupVO());

        try {
            _sqlMode = SqlMode.VO;
            _condition = condition;
            return (List<Mbj26BillGroupVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * IN句で特定のグループで検索を行い、データを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj26BillGroupVO> selectIN(String groupCd) throws HAMException {

        super.setModel(new Mbj26BillGroupVO());

        try {
            _sqlMode = SqlMode.IN;
            _groupCd = groupCd;
            return (List<Mbj26BillGroupVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /* 2016/02/04 請求業務変更対応 HLC K.Soga MOD Start */
//    /**
//     * HC部門コード(Fee案件請求用)取得
//     * @return 検索結果
//     * @throws HAMException
//     */
//    @SuppressWarnings("unchecked")
//    public List<Mbj26BillGroupVO> selectBillGroupVO() throws HAMException {
//
//        super.setModel(new Mbj26BillGroupVO());
//
//        try {
//            _sqlMode = SqlMode.BILL;
//            return (List<Mbj26BillGroupVO>) super.find();
//        } catch (UserException e) {
//            throw new HAMException(e.getMessage(), "BJ-E0001");
//        }
//    }
    /**
     * HC部門コード(Fee案件請求用)MAP格納用取得
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj26BillGroupVO> selectBillGroupVO(String groupCd) throws HAMException {

        super.setModel(new Mbj26BillGroupVO());

        try {
            _sqlMode = SqlMode.BILL;
            _groupCd = groupCd;
            return (List<Mbj26BillGroupVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * HC部門コード(Fee案件請求用)取得
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj26BillGroupVO> selectHCBumonBillGroupVO(String groupCd) throws HAMException {

        super.setModel(new Mbj26BillGroupVO());

        try {
            _sqlMode = SqlMode.HCBUMONBILL;
            _groupCd = groupCd;
            return (List<Mbj26BillGroupVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
    /* 2016/02/04 請求業務変更対応 HLC K.Soga MOD End */
}
