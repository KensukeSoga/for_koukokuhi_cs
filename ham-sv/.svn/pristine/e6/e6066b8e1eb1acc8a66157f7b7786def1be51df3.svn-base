package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj16ContractInfo;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 契約情報DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * ・HDX対応(2016/02/25 HLC K.Oki)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj16ContractInfoDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private List<Tbj16ContractInfoVO> _conditions = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode{LOAD, COND, MAXHIS, LOCK, LIST, CATEGORY };
    private SelSqlMode _SelSqlMode = SelSqlMode.LOAD;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj16ContractInfoDAO() {
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
                Tbj16ContractInfo.CTRTKBN
                ,Tbj16ContractInfo.CTRTNO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj16ContractInfo.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj16ContractInfo.CRTDATE
                ,Tbj16ContractInfo.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj16ContractInfo.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj16ContractInfo.CTRTKBN
                ,Tbj16ContractInfo.CTRTNO
                ,Tbj16ContractInfo.DCARCD
                ,Tbj16ContractInfo.CATEGORY
                ,Tbj16ContractInfo.DELFLG
                ,Tbj16ContractInfo.NAMES
                ,Tbj16ContractInfo.DATEFROM
                ,Tbj16ContractInfo.DATETO
                ,Tbj16ContractInfo.MUSIC
                ,Tbj16ContractInfo.JASRACFLG
                ,Tbj16ContractInfo.SALEFLG
                /* 2016/02/24 HDX対応 HLC K.Oki ADD Start */
                ,Tbj16ContractInfo.ENDTITLEFLG
                ,Tbj16ContractInfo.ARRGORGFLG
                /* 2016/02/24 HDX対応 HLC K.Oki ADD End */
                ,Tbj16ContractInfo.BIKO
                ,Tbj16ContractInfo.HISTORYKEY
                ,Tbj16ContractInfo.CRTDATE
                ,Tbj16ContractInfo.CRTNM
                ,Tbj16ContractInfo.CRTAPL
                ,Tbj16ContractInfo.CRTID
                ,Tbj16ContractInfo.UPDDATE
                ,Tbj16ContractInfo.UPDNM
                ,Tbj16ContractInfo.UPDAPL
                ,Tbj16ContractInfo.UPDID
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
            sql.append(" ORDER BY ");
            sql.append(" " + Tbj16ContractInfo.DATETO + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.LIST)) {

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
            sql.append(" ORDER BY ");
            sql.append("  " + Tbj16ContractInfo.CRTDATE + " ");
            sql.append(" ," + Tbj16ContractInfo.DATETO + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.MAXHIS)) {

            //*******************************************
            //findMaxで使用されるSQL
            //*******************************************
            //SELECT + FROM句
            sql.append(" SELECT ");
            sql.append("     NVL(MAX(" + Tbj16ContractInfo.HISTORYKEY  + "), 0) AS " + Tbj16ContractInfo.HISTORYKEY + " ");
            sql.append(" FROM ");
            sql.append(" " + Tbj16ContractInfo.TBNAME + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.LOCK)) {

            // *******************************************
            // 排他用SQL
            // *******************************************
            sql.append(" SELECT ");
            sql.append(" " + getTimeStampKeyName() + " ");
            for (int i = 0; i < getPrimryKeyNames().length; i++) {
                sql.append(" ," + getPrimryKeyNames()[i] +" ");
            }
            sql.append(" FROM ");
            sql.append(" " + getTableName() + " ");
            sql.append(" WHERE ");
            for (int i = 0; i < _conditions.size(); i++) {
                AbstractModel cond = _conditions.get(i);
                sql.append((i != 0 ? " OR " : " "));
                sql.append(" ( ");
                for (int j = 0; j < getPrimryKeyNames().length; j++) {
                    sql.append((j != 0 ? " AND " : " "));
                    sql.append("" + getPrimryKeyNames()[j] +" ");
                    sql.append(" = ");
                    sql.append(getDBModelInterface().ConvertToDBString(cond.get(getPrimryKeyNames()[j])));
                }
                sql.append(" ) ");
            }

        } else if (_SelSqlMode.equals(SelSqlMode.CATEGORY)) {

            sql.append(" SELECT ");
            sql.append("    " + Tbj16ContractInfo.CATEGORY + " ");
            sql.append(" FROM ");
            sql.append("    " + Tbj16ContractInfo.TBNAME + " ");
            sql.append(" GROUP BY ");
            sql.append("    " + Tbj16ContractInfo.CATEGORY + " ");
            sql.append(" ORDER BY ");
            sql.append("    MIN(" + Tbj16ContractInfo.CRTDATE + ") ");

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
     * ConditionからVOに変換する
     * @param cond
     * @return
     */
    private Tbj16ContractInfoVO convertCondToVo(Tbj16ContractInfoCondition cond) {
        Tbj16ContractInfoVO vo = new Tbj16ContractInfoVO();

        vo.setCTRTKBN(cond.getCtrtkbn());
        vo.setCTRTNO(cond.getCtrtno());
        vo.setDCARCD(cond.getDcarcd());
        vo.setCATEGORY(cond.getCategory());
        vo.setDELFLG(cond.getDelflg());
        vo.setNAMES(cond.getNames());
        vo.setDATEFROM(cond.getDatefrom());
        vo.setDATETO(cond.getDateto());
        vo.setMUSIC(cond.getMusic());
        vo.setJASRACFLG(cond.getJasracflg());
        vo.setSALEFLG(cond.getSaleflg());
        /* 2016/02/24 HDX対応 HLC K.Oki ADD Start */
        vo.setENDTITLEFLG(cond.getEndtitleflg());
        vo.setARRGORGFLG(cond.getArrgorgflg());
        /* 2016/02/24 HDX対応 HLC K.Oki ADD End */
        vo.setBIKO(cond.getBiko());
        vo.setCRTDATE(cond.getCrtdate());
        vo.setCRTNM(cond.getCrtnm());
        vo.setCRTAPL(cond.getCrtapl());
        vo.setCRTID(cond.getCrtid());
        vo.setUPDDATE(cond.getUpddate());
        vo.setUPDNM(cond.getUpdnm());
        vo.setUPDAPL(cond.getUpdapl());
        vo.setUPDID(cond.getUpdid());

        return vo;
    }

    /**
     * PKを条件にして検索を行います(複数指定可)
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj16ContractInfoVO> selectByPkWithLock(List<Tbj16ContractInfoVO> cond) throws HAMException {
        // パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Tbj16ContractInfoVO());
        try {
            _SelSqlMode = SelSqlMode.LOCK;
            _conditions = cond;
            return (List<Tbj16ContractInfoVO>) super.find();
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
    public List<Tbj16ContractInfoVO> selectVO(Tbj16ContractInfoCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(convertCondToVo(cond));
        try {
            _SelSqlMode = SelSqlMode.COND;
            return (List<Tbj16ContractInfoVO>)super.find();
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
    public List<Tbj16ContractInfoVO> selectVOForLIST(Tbj16ContractInfoCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(convertCondToVo(cond));
        try {
            _SelSqlMode = SelSqlMode.LIST;
            return (List<Tbj16ContractInfoVO>)super.find();
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
    public Tbj16ContractInfoVO loadVO(Tbj16ContractInfoVO cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(cond);
        try {
            return (Tbj16ContractInfoVO)super.load();
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
    public void insertVO(Tbj16ContractInfoVO vo) throws HAMException {
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
    public void updateVO(Tbj16ContractInfoVO vo) throws HAMException {
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
    public void deleteVO(Tbj16ContractInfoVO vo) throws HAMException {
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

    /**
     * HISTORYKEYの現在の最大値を取得します
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj16ContractInfoVO> findMax(Tbj16ContractInfoCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Tbj16ContractInfoVO());
        try {
            _SelSqlMode = SelSqlMode.MAXHIS;
            return (List<Tbj16ContractInfoVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * カテゴリを取得します
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj16ContractInfoVO> getCategory() throws HAMException {
        super.setModel(new Tbj16ContractInfoVO());
        try {
            _SelSqlMode = SelSqlMode.CATEGORY;
            return (List<Tbj16ContractInfoVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
