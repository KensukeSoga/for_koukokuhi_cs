package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj50RdStation;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.ConcurrentUpdateException;
import jp.co.isid.nj.integ.UpdateFailureException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ラジオ局マスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj50RdStationDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Mbj50RdStationCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj50RdStationDAO() {
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
                Mbj50RdStation.RDCD
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Mbj50RdStation.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj50RdStation.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Mbj50RdStation.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj50RdStation.RDCD
                ,Mbj50RdStation.RDNM
                ,Mbj50RdStation.ABBREVIATION
                ,Mbj50RdStation.JASRACREPORTNM
                ,Mbj50RdStation.JFNGRPFLG
                ,Mbj50RdStation.JRNGRPFLG
                ,Mbj50RdStation.NRNGRPFLG
                ,Mbj50RdStation.SORTNO
                ,Mbj50RdStation.UPDDATE
                ,Mbj50RdStation.UPDNM
                ,Mbj50RdStation.UPDAPL
                ,Mbj50RdStation.UPDID
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

        if (super.getModel() instanceof Mbj50RdStationVO) {

            //Mbj50RdStationVO取得用SQL取得
            sql = getSelectSQLMbj50RdStationVO();
        }

        return sql;
    }

    /**
     * SELECT SQL(Mbj50RdStationVO)
     */
    private String getSelectSQLMbj50RdStationVO() {

        StringBuffer selectSql = new StringBuffer();
        String whereSqlStr = "";
        StringBuffer orderSql = new StringBuffer();

        //*******************************************
        //load()、find()で使用されるSELECT + FROM句のSQL
        //*******************************************
        selectSql.append(" SELECT");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            selectSql.append((i != 0 ? " ," : " "));
            selectSql.append(getTableColumnNames()[i] + " ");
        }

        selectSql.append(" FROM");
        selectSql.append(" " + getTableName());

        if (_condition != null) {

            Mbj50RdStationVO vo = new Mbj50RdStationVO();

            vo.setRDCD(_condition.getRdcd());
            vo.setRDNM(_condition.getRdnm());
            vo.setABBREVIATION(_condition.getAbbreviation());
            vo.setJASRACREPORTNM(_condition.getJasracreportnm());
            vo.setJFNGRPFLG(_condition.getJfngrpflg());
            vo.setJRNGRPFLG(_condition.getJrngrpflg());
            vo.setNRNGRPFLG(_condition.getNrngrpflg());
            vo.setSORTNO(_condition.getSortno());
            vo.setUPDDATE(_condition.getUpddate());
            vo.setUPDNM(_condition.getUpdnm());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDID(_condition.getUpdid());

            whereSqlStr = generateWhereByCond(vo);
        }

        orderSql.append(" ORDER BY ");
        orderSql.append(" " + Mbj50RdStation.SORTNO + " ");

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    }

    /**
     * InsertVO
     * @param vo データ
     * @throws HAMException
     */
    public void insertVO(Mbj50RdStationVO vo) throws HAMException {

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
    public void updateVO(Mbj50RdStationVO vo) throws HAMException {

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
    public void deleteVO(Mbj50RdStationVO vo) throws HAMException {

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
            //処理件数「0」の場合

            //正常とする(削除レコードなし)
            return;
        } catch(UpdateFailureException e) {
            // 処理件数「2以上」の場合

            //正常とする
            return;
        } catch(UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    /**
     * SelectVO
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj50RdStationVO> selectVO(Mbj50RdStationCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Mbj50RdStationVO());
        _condition = condition;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
