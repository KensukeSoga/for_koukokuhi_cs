package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj45CrExpConvert;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * CR予算費目変換マスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj45CrExpConvertDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Mbj45CrExpConvertCondition _condition = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode {
        LOAD, VO, CNV,
    };

    private SelSqlMode _SelSqlMode = SelSqlMode.LOAD;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj45CrExpConvertDAO() {
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
                Mbj45CrExpConvert.EXPCD
                ,Mbj45CrExpConvert.CLASSDIV
                ,Mbj45CrExpConvert.DATEFROM
                ,Mbj45CrExpConvert.DATETO
                ,Mbj45CrExpConvert.NEWCLASSDIV
                ,Mbj45CrExpConvert.NEWDATEFROM
                ,Mbj45CrExpConvert.NEWDATETO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Mbj45CrExpConvert.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj45CrExpConvert.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Mbj45CrExpConvert.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj45CrExpConvert.EXPCD
                ,Mbj45CrExpConvert.CLASSDIV
                ,Mbj45CrExpConvert.DATEFROM
                ,Mbj45CrExpConvert.DATETO
                ,Mbj45CrExpConvert.NEWEXPCD
                ,Mbj45CrExpConvert.NEWCLASSDIV
                ,Mbj45CrExpConvert.NEWDATEFROM
                ,Mbj45CrExpConvert.NEWDATETO
                ,Mbj45CrExpConvert.UPDDATE
                ,Mbj45CrExpConvert.UPDNM
                ,Mbj45CrExpConvert.UPDAPL
                ,Mbj45CrExpConvert.UPDID
        };
    }

    /**
     * デフォルトのSQL文を返します
     */
    @Override
    public String getSelectSQL() {
        StringBuffer selectSql = new StringBuffer();
        StringBuffer whereSql = new StringBuffer();
        StringBuffer orderSql = new StringBuffer();

        if (_SelSqlMode.equals(SelSqlMode.LOAD)) {

            // *******************************************
            // Load()で使用されるSELECT + FROM句のSQL
            // *******************************************
            selectSql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                selectSql.append((i != 0 ? " ," : " "));
                selectSql.append("" + getTableColumnNames()[i] + " ");
            }
            selectSql.append(" FROM ");
            selectSql.append(" " + getTableName() + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.VO)) {

            // *******************************************
            // selectVOで使用されるSQL
            // *******************************************
            // SELECT + FROM句
            selectSql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                selectSql.append((i != 0 ? " ," : " "));
                selectSql.append("" + getTableColumnNames()[i] + " ");
            }
            selectSql.append(" FROM ");
            selectSql.append(" " + getTableName() + " ");

            // WHERE句
            if (_condition != null) {
                Mbj45CrExpConvertVO vo = new Mbj45CrExpConvertVO();
                vo.setEXPCD(_condition.getExpcd());
                vo.setCLASSDIV(_condition.getClassdiv());
                vo.setDATEFROM(_condition.getDatefrom());
                vo.setDATETO(_condition.getDateto());
                vo.setNEWEXPCD(_condition.getNewexpcd());
                vo.setNEWCLASSDIV(_condition.getNewclassdiv());
                vo.setNEWDATEFROM(_condition.getNewdatefrom());
                vo.setNEWDATETO(_condition.getNewdateto());
                vo.setUPDDATE(_condition.getUpddate());
                vo.setUPDNM(_condition.getUpdnm());
                vo.setUPDAPL(_condition.getUpdapl());
                vo.setUPDID(_condition.getUpdid());

                whereSql.append(generateWhereByCond(vo));
            }

        } else if (_SelSqlMode.equals(SelSqlMode.CNV)) {

            Mbj45CrExpConvertVO cond = (Mbj45CrExpConvertVO)super.getModel();

            //SELECT + FROM句
            selectSql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                selectSql.append((i != 0 ? " ," : " "));
                selectSql.append("" + getTableColumnNames()[i] +" ");
            }
            selectSql.append(" FROM ");
            selectSql.append(" " + getTableName() + " ");

            //WHERE句
            whereSql.append(" WHERE ");
            whereSql.append("     " + Mbj45CrExpConvert.EXPCD        +" = "  + super.getDBModelInterface().ConvertToDBString(cond.getEXPCD())  + " ");
            whereSql.append(" AND " + Mbj45CrExpConvert.CLASSDIV     +" = "  + super.getDBModelInterface().ConvertToDBString(cond.getCLASSDIV())  + " ");
            whereSql.append(" AND " + Mbj45CrExpConvert.DATEFROM     +" <= " + super.getDBModelInterface().ConvertToDBString(cond.getDATEFROM())  + " ");
            whereSql.append(" AND " + Mbj45CrExpConvert.DATETO       +" >= " + super.getDBModelInterface().ConvertToDBString(cond.getDATETO())  + " ");
            whereSql.append(" AND " + Mbj45CrExpConvert.NEWCLASSDIV  +" = "  + super.getDBModelInterface().ConvertToDBString(cond.getNEWCLASSDIV())  + " ");
            whereSql.append(" AND " + Mbj45CrExpConvert.NEWDATEFROM  +" <= " + super.getDBModelInterface().ConvertToDBString(cond.getNEWDATEFROM())  + " ");
            whereSql.append(" AND " + Mbj45CrExpConvert.NEWDATETO    +" >= " + super.getDBModelInterface().ConvertToDBString(cond.getNEWDATETO())  + " ");
        }

        return selectSql.toString() + whereSql.toString() + orderSql.toString();
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
                }
                else {
                    sql.append(" AND ");
                }
                sql.append(getTableColumnNames()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
            }
        }

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj45CrExpConvertVO> selectVO(Mbj45CrExpConvertVO condition) throws HAMException {

        super.setModel(condition);
        try {
            _SelSqlMode = SelSqlMode.VO;
            return (List<Mbj45CrExpConvertVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
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
    public List<Mbj45CrExpConvertVO> selectVO(Mbj45CrExpConvertCondition condition) throws HAMException {

        super.setModel(new Mbj30InputTntVO());
        try {
            _SelSqlMode = SelSqlMode.VO;
            _condition = condition;
            return (List<Mbj45CrExpConvertVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
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
    public List<Mbj45CrExpConvertVO> selectVOForCNV(Mbj45CrExpConvertVO condition) throws HAMException {

        super.setModel(condition);
        try {
            _SelSqlMode = SelSqlMode.CNV;
            return (List<Mbj45CrExpConvertVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
