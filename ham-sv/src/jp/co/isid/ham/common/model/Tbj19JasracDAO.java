package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj19Jasrac;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * JASRACDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj19JasracDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj19JasracCondition _condition = null;
    private List<Tbj19JasracVO> _conditions = null;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj19JasracDAO() {
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
                Tbj19Jasrac.PHASE
                ,Tbj19Jasrac.QUOTEKBN
                ,Tbj19Jasrac.SEIKYUYM
                ,Tbj19Jasrac.CTRTKBN
                ,Tbj19Jasrac.CTRTNO
        };
    }

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode{LOAD, COND, MAXTIME, MULTIPK,};
    private SelSqlMode _SelSqlMode = SelSqlMode.LOAD;

    /** getExecSQLで発行するSQLのモード() */
    private enum ExecSqlMode{COND,  };
    private ExecSqlMode _ExecSqlMode = ExecSqlMode.COND;

    private enum StoreMode {INS, UPD, };
    private StoreMode _StoreMode = null;

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj19Jasrac.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        if (StoreMode.INS.equals(_StoreMode)) {
            return new String[] {
                    Tbj19Jasrac.CRTDATE
                    ,Tbj19Jasrac.UPDDATE
            };
        } else if (StoreMode.UPD.equals(_StoreMode)) {
            return new String[] {
                    Tbj19Jasrac.UPDDATE
            };
        } else {
            return new String[] {};
        }
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj19Jasrac.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj19Jasrac.PHASE
                ,Tbj19Jasrac.QUOTEKBN
                ,Tbj19Jasrac.SEIKYUYM
                ,Tbj19Jasrac.CTRTKBN
                ,Tbj19Jasrac.CTRTNO
                ,Tbj19Jasrac.DELFLG
                ,Tbj19Jasrac.DATEFROM
                ,Tbj19Jasrac.DATETO
                ,Tbj19Jasrac.EIGYNO1
                ,Tbj19Jasrac.EIGYNO2
                ,Tbj19Jasrac.BIKO
                ,Tbj19Jasrac.CRTDATE
                ,Tbj19Jasrac.CRTNM
                ,Tbj19Jasrac.CRTAPL
                ,Tbj19Jasrac.CRTID
                ,Tbj19Jasrac.UPDDATE
                ,Tbj19Jasrac.UPDNM
                ,Tbj19Jasrac.UPDAPL
                ,Tbj19Jasrac.UPDID
        };
    }

   /**
    * 値の設定有無からSQLのWHERE句を生成する
    * @param vo
    * @return
    */
   private String generateWhereByCond(AbstractModel vo)
   {
       StringBuffer sql = new StringBuffer();

       for (int i = 0; i < getTableColumnNames().length; i++)
       {
           Object value = vo.get(getTableColumnNames()[i]);
           if (value != null)
           {
               if (sql.length() == 0)
               {
                   sql.append(" WHERE ");
               }
               else
               {
                   sql.append(" AND ");
               }
               sql.append(getTableColumnNames()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
           }
       }

       return sql.toString();
   }

    /**
     * デフォルトのSQL文を返します
     */
    @Override
    public String getSelectSQL()
    {
        StringBuffer sql = new StringBuffer();

        if (_SelSqlMode.equals(SelSqlMode.LOAD)) {

            //*******************************************
            //Load()で使用されるSELECT + FROM句のSQL
            //*******************************************
            sql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++)
            {
                sql.append((i != 0 ? " ," : " "));
                sql.append("" + getTableColumnNames()[i] +" ");
            }
            sql.append(" FROM ");
            sql.append(" " + getTableName() + " ");
        }

        else if (_SelSqlMode.equals(SelSqlMode.COND)) {

            //*******************************************
            //selectVOで使用されるSQL
            //*******************************************
            //SELECT + FROM句
            sql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++)
            {
                sql.append((i != 0 ? " ," : " "));
                sql.append("" + getTableColumnNames()[i] +" ");
            }
            sql.append(" FROM ");
            sql.append(" " + getTableName() + " ");
            //WHERE句
            sql.append(generateWhereByCond(getModel()));
        }

        else if (_SelSqlMode.equals(SelSqlMode.MAXTIME)) {

            //*******************************************
            //findMaxTimeStampで使用されるSQL
            //*******************************************
            //SELECT + FROM + ORDER BY句
            sql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++)
            {
                sql.append((i != 0 ? " ," : " "));
                sql.append("" + getTableColumnNames()[i] +" ");
            }
            sql.append(" FROM ");
            sql.append(" " + getTableName() + " ");
            //WHERE句
            sql.append(generateWhereByCond(getModel()));
            //ORDER BY句
            sql.append(" ORDER BY " + Tbj19Jasrac.UPDDATE + " DESC ");

        } else if (_SelSqlMode.equals(SelSqlMode.MULTIPK)) {

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
        }

        return sql.toString();
    }

    /**
     * PKを条件にして検索を行います(複数指定可)
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj19JasracVO> selectByMultiPk(List<Tbj19JasracVO> cond) throws HAMException {
        // パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Tbj19JasracVO());
        try {
            _SelSqlMode = SelSqlMode.MULTIPK;
            _conditions = cond;
            return (List<Tbj19JasracVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /*
    * 指定した条件で検索を行い、データを取得します
    * @param cond
    * @return
    * @throws HAMException
    */
   @SuppressWarnings("unchecked")
   public List<Tbj19JasracVO> selectVO(Tbj19JasracCondition cond) throws HAMException
   {
       //パラメータチェック
       if (cond == null)
       {
           throw new HAMException("検索エラー", "BJ-E0001");
       }
       super.setModel(convertCondToVo(cond));;
       try
       {
           _SelSqlMode = SelSqlMode.COND;
           return (List<Tbj19JasracVO>)super.find();
       }
       catch (UserException e)
       {
           throw new HAMException(e.getMessage(), "BJ-E0001");
       }
   }

    /**
     * PK検索
     * @param cond
     * @return
     * @throws HAMException
     */
    public Tbj19JasracVO loadVO(Tbj19JasracVO cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(cond);
        try {
            return (Tbj19JasracVO)super.load();
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
    public void insertVO(Tbj19JasracVO vo) throws HAMException {
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
    public void updateVO(Tbj19JasracVO vo) throws HAMException {
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
    public void deleteVO(Tbj19JasracVO vo) throws HAMException {
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
     * UPDDATE降順でデータを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj19JasracVO> findMaxTimeStamp(Tbj19JasracCondition cond) throws HAMException {
        // パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(convertCondToVo(cond));
        try {
            _SelSqlMode = SelSqlMode.MAXTIME;
//            _condition = cond;
            return (List<Tbj19JasracVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }


    /**
     * CondtionからVOに変換する
     * @param cond
     * @return
     */
    private static AbstractModel convertCondToVo(Tbj19JasracCondition cond) {
        Tbj19JasracVO vo = new Tbj19JasracVO();

        vo.setPHASE(cond.getPhase());
        vo.setQUOTEKBN(cond.getQuotekbn());
        vo.setSEIKYUYM(cond.getSeikyuym());
        vo.setCTRTKBN(cond.getCtrtkbn());
        vo.setCTRTNO(cond.getCtrtno());
        vo.setDELFLG(cond.getDelflg());
        vo.setCRTNM(cond.getCrtnm());
        vo.setDATEFROM(cond.getDatefrom());
        vo.setDATETO(cond.getDateto());
        vo.setEIGYNO1(cond.getEigyno1());
        vo.setEIGYNO2(cond.getEigyno2());
        vo.setUPDAPL(cond.getUpdapl());
        vo.setUPDDATE(cond.getUpddate());
        vo.setUPDID(cond.getUpdid());
        vo.setUPDNM(cond.getUpdnm());

        return vo;
    }

    @Override
    public String getExecString() {
        String sql = "";

        if (_ExecSqlMode.equals(ExecSqlMode.COND)) {
            sql = getExecStringForCOND();
        }

        return sql.toString();
    }

    /**
     * 更新SQLを取得する
     * @return
     */
    private String getExecStringForCOND() {
        StringBuffer sql = new StringBuffer();

        sql.append(" UPDATE ");
        sql.append("     " + getTableName() + " ");
        //SET句---------------------------------------------------------------------------------------------------------
        sql.append(generateSetByCond(getModel()));
        //WHERE句-------------------------------------------------------------------------------------------------------
        sql.append(generateWhereByCond(convertCondToVo(_condition)));

        return sql.toString();
    }

    /**
     * 値の設定有無からUPDATEのSET句を生成する
     * @param vo
     * @return
     */
    private String generateSetByCond(AbstractModel vo) {
        StringBuffer sql = new StringBuffer();

        for (int i = 0; i < getTableColumnNames().length; i++) {
            String columnName = getTableColumnNames()[i];
            Object value = vo.get(columnName);
            if (getTimeStampKeyName().equals(columnName)) {
                //システム日付で更新する項目の場合は値の有無に関係なくSYSDATEで更新
                if (sql.length() == 0) {
                    sql.append(" SET ");
                } else {
                    sql.append("    ,");
                }
                sql.append(columnName + " = " + getDBModelInterface().getSystemDateString());
            } else {
                if (value != null) {
                //if (vo.getUpdateMember().containsKey(columnName)) {
                    if (sql.length() == 0) {
                        sql.append(" SET ");
                    } else {
                        sql.append("    ,");
                    }
                    if (value != null) {
                        sql.append(columnName + " = " + getDBModelInterface().ConvertToDBString(value));
                    }
                }
            }
        }

        return sql.toString();
    }

    /**
     * Conditionで指定した条件、VOの内容で更新する
     * @param vo
     * @param cond
     * @throws HAMException
     */
    public void updateVOByCond(Tbj19JasracVO vo, Tbj19JasracCondition cond) throws HAMException {

        //パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);
        _condition = cond;
        try {
            _StoreMode = StoreMode.UPD;
            _ExecSqlMode = ExecSqlMode.COND;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }
}
