package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj10CrCarInfo;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * CR車種情報ヘッダDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj10CrCarInfoDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
//    private Tbj10CrCarInfoCondition _condition = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode{LOAD, COND, MAXTIME, };
    private SelSqlMode _SelSqlMode = SelSqlMode.LOAD;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj10CrCarInfoDAO() {
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
                Tbj10CrCarInfo.DCARCD
                ,Tbj10CrCarInfo.PHASE
                ,Tbj10CrCarInfo.CRDATE
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj10CrCarInfo.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj10CrCarInfo.CRTDATE
                ,Tbj10CrCarInfo.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj10CrCarInfo.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj10CrCarInfo.DCARCD
                ,Tbj10CrCarInfo.PHASE
                ,Tbj10CrCarInfo.CRDATE
                ,Tbj10CrCarInfo.RAP
                ,Tbj10CrCarInfo.CPUSER
                ,Tbj10CrCarInfo.CDSTAFF
                ,Tbj10CrCarInfo.CRCOMPANY
                ,Tbj10CrCarInfo.SCHEDULE1
                ,Tbj10CrCarInfo.SCHEDULE2
                ,Tbj10CrCarInfo.SCHEDULE3
                ,Tbj10CrCarInfo.NOTE
                ,Tbj10CrCarInfo.CRTDATE
                ,Tbj10CrCarInfo.CRTNM
                ,Tbj10CrCarInfo.CRTAPL
                ,Tbj10CrCarInfo.CRTID
                ,Tbj10CrCarInfo.UPDDATE
                ,Tbj10CrCarInfo.UPDNM
                ,Tbj10CrCarInfo.UPDAPL
                ,Tbj10CrCarInfo.UPDID
        };
    }


    /**
     * デフォルトのSQL文を返します
     */
    @Override
    public String getSelectSQL() {
        StringBuffer sql = new StringBuffer();

        if (_SelSqlMode.equals(SelSqlMode.LOAD)) {

            //*******************************************
            //Load()で使用されるSELECT + FROM句のSQL
            //*******************************************
            sql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                sql.append((i != 0 ? " ," : " "));
                sql.append("" + getTableColumnNames()[i] +" ");
            }
            sql.append(" FROM ");
            sql.append(" " + getTableName() + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.COND)) {

            //*******************************************
            //selectVOで使用されるSQL
            //*******************************************
            //SELECT + FROM句
            sql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                sql.append((i != 0 ? " ," : " "));
                sql.append("" + getTableColumnNames()[i] +" ");
            }
            sql.append(" FROM ");
            sql.append(" " + getTableName() + " ");
            //WHERE句
            sql.append(generateWhereByCond(getModel()));

        } else if (_SelSqlMode.equals(SelSqlMode.MAXTIME)) {

            // *******************************************
            // findMaxTimeStampで使用されるSQL
            // *******************************************
            sql.append(" SELECT ");
            sql.append("     NVL(MAX(" + getTimeStampKeyName() + "), SYSDATE) AS " + getTimeStampKeyName() + " ");
            sql.append(" FROM ");
            sql.append(" " + getTableName() + " ");
            //WHERE句
            sql.append(generateWhereByCond(getModel()));
        }

        return sql.toString();
    };

    /**
     * 値の設定有無からSQLのWHERE句を生成する
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
     * CondtionからVOに変換する
     * @param cond
     * @return
     */
    private Tbj10CrCarInfoVO convertCondToVo(Tbj10CrCarInfoCondition cond) {
        Tbj10CrCarInfoVO vo = new Tbj10CrCarInfoVO();

        vo.setCDSTAFF(cond.getCdstaff());
        vo.setCPUSER(cond.getCpuser());
        vo.setCRCOMPANY(cond.getCrcompany());
        vo.setCRDATE(cond.getCrdate());
        vo.setCRTDATE(cond.getCrtdate());
        vo.setCRTNM(cond.getCrtnm());
        vo.setDCARCD(cond.getDcarcd());
        vo.setNOTE(cond.getNote());
        vo.setPHASE(cond.getPhase());
        vo.setRAP(cond.getRap());
        vo.setSCHEDULE1(cond.getSchedule1());
        vo.setSCHEDULE2(cond.getSchedule2());
        vo.setSCHEDULE3(cond.getSchedule3());
        vo.setUPDAPL(cond.getUpdapl());
        vo.setUPDDATE(cond.getUpddate());
        vo.setUPDID(cond.getUpdid());
        vo.setUPDNM(cond.getUpdnm());

        return vo;
    }

    /**
     * TIMESTAMP項目の現在の最大値を取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj10CrCarInfoVO> findMaxTimeStamp(Tbj10CrCarInfoCondition cond) throws HAMException {
        // パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(convertCondToVo(cond));
        try {
            _SelSqlMode = SelSqlMode.MAXTIME;
//            _condition = cond;
            return (List<Tbj10CrCarInfoVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    //public List<Tbj10CrCarInfoVO> selectVO(Tbj10CrCarInfoCondition cond) throws HAMException {
    public List<Tbj10CrCarInfoVO> selectVO(Tbj10CrCarInfoVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(vo);
        try {
            _SelSqlMode = SelSqlMode.COND;
            return (List<Tbj10CrCarInfoVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * PK検索
     * @param cond
     * @return
     * @throws HAMException
     */
    public Tbj10CrCarInfoVO loadVO(Tbj10CrCarInfoVO cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(cond);
        try {
            return (Tbj10CrCarInfoVO)super.load();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 登録
     * @param vo
     * @return
     * @throws HAMException
     */
    public void insertVO(Tbj10CrCarInfoVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);
        try {
            super.insert();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * PK更新
     * @param vo
     * @return
     * @throws HAMException
     */
    public void updateVO(Tbj10CrCarInfoVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);
        try {
            super.update();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * PK削除
     * @param vo
     * @return
     * @throws HAMException
     */
    public void deleteVO(Tbj10CrCarInfoVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("削除エラー", "BJ-E0004");
        }
        super.setModel(vo);
        try {
            super.remove();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

}
