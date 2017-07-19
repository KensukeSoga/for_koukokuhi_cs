package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj35Knr;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 管理テーブルDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/05/02 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj35KnrDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj35KnrCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj35KnrDAO() {
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
                Tbj35Knr.SYSTEMNO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj35Knr.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj35Knr.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj35Knr.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj35Knr.SYSTEMNO
                ,Tbj35Knr.SYSTEMNAME
                ,Tbj35Knr.KANRIFLG
                ,Tbj35Knr.RSTAYOKBN
                ,Tbj35Knr.RENDYOKBN
                ,Tbj35Knr.DAYCHGKBN
                ,Tbj35Knr.RSTARTTIME
                ,Tbj35Knr.RENDTIME
                ,Tbj35Knr.EIGYOBI
                ,Tbj35Knr.MSG01
                ,Tbj35Knr.MSG02
                ,Tbj35Knr.MSG03
                ,Tbj35Knr.MSG04
                ,Tbj35Knr.MSG05
                ,Tbj35Knr.BIKOU
                ,Tbj35Knr.HYOUJIKBN
                ,Tbj35Knr.BATCHFLG
                ,Tbj35Knr.UPDDATE
                ,Tbj35Knr.UPDNM
                ,Tbj35Knr.UPDAPL
                ,Tbj35Knr.UPDID
        };
    }

    /**
     * AbstractModelの値の設定有無からSQLのWHERE句を生成する
     * @param vo
     * @return
     */
    private String generateWhereByCond(AbstractModel vo)
    {
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
    public String getSelectSQL()
    {
        String sql = "";

        if (super.getModel() instanceof Tbj35KnrVO)
        {
            // Tbj35KnrVO取得用SQL取得
            sql = getSelectSQLTbj35KnrVO();
        }

        return sql;

    };

    /**
     * SELECT SQL（Tbj35KnrVO）
     */
    private String getSelectSQLTbj35KnrVO()
    {
        StringBuffer selectSql = new StringBuffer();
        String whereSqlStr = "";
        StringBuffer orderSql = new StringBuffer();

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

        if (_condition != null)
        {
            Tbj35KnrVO vo = new Tbj35KnrVO();
            vo.setSYSTEMNO(_condition.getSystemno());
            vo.setSYSTEMNAME(_condition.getSystemname());
            vo.setKANRIFLG(_condition.getKanriflg());
            vo.setRSTAYOKBN(_condition.getRstayokbn());
            vo.setRENDYOKBN(_condition.getRendyokbn());
            vo.setDAYCHGKBN(_condition.getDaychgkbn());
            vo.setRSTARTTIME(_condition.getRstarttime());
            vo.setRENDTIME(_condition.getRendtime());
            vo.setEIGYOBI(_condition.getEigyobi());
            vo.setMSG01(_condition.getMsg01());
            vo.setMSG02(_condition.getMsg02());
            vo.setMSG03(_condition.getMsg03());
            vo.setMSG04(_condition.getMsg04());
            vo.setMSG05(_condition.getMsg05());
            vo.setBIKOU(_condition.getBikou());
            vo.setHYOUJIKBN(_condition.getHyoujikbn());
            vo.setBATCHFLG(_condition.getBatchflg());
            vo.setUPDDATE(_condition.getUpddate());
            vo.setUPDNM(_condition.getUpdnm());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDID(_condition.getUpdid());
            whereSqlStr = generateWhereByCond(vo);
        }

        orderSql.append(" ORDER BY ");
        orderSql.append(" " + Tbj35Knr.SYSTEMNO + " ");

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    };

    /**
     * SelectVO
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj35KnrVO> selectVO(Tbj35KnrCondition condition) throws HAMException
    {
        // パラメータチェック
        if (condition == null)
        {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj35KnrVO());
        _condition = condition;

        try
        {
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
