package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.nj.integ.ConcurrentUpdateException;
import jp.co.isid.nj.integ.UpdateFailureException;
import jp.co.isid.ham.integ.tbl.Mbj08HcProduct;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HC商品マスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj08HcProductDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Mbj08HcProductCondition _condition = null;

    /** 全削除フラグ */
    private boolean _allDelFlg = false;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj08HcProductDAO() {
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
                Mbj08HcProduct.HCPRODUCTCD
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Mbj08HcProduct.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj08HcProduct.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Mbj08HcProduct.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj08HcProduct.HCPRODUCTCD
                ,Mbj08HcProduct.USEBUMONCD
                ,Mbj08HcProduct.USEBUMONNM
                ,Mbj08HcProduct.MEDIACLASSCD
                ,Mbj08HcProduct.MEDIACLASSNM
                ,Mbj08HcProduct.MEDIACD
                ,Mbj08HcProduct.MEDIANM
                ,Mbj08HcProduct.BUSINESSCLASSCD
                ,Mbj08HcProduct.BUSINESSCLASSNM
                ,Mbj08HcProduct.BUSINESSCD
                ,Mbj08HcProduct.BUSINESSNM
                ,Mbj08HcProduct.PRODUCTCD
                ,Mbj08HcProduct.PRODUCTNM
                ,Mbj08HcProduct.WEEKCD
                ,Mbj08HcProduct.WEEK
                ,Mbj08HcProduct.SIZECD
                ,Mbj08HcProduct.SIZE
                ,Mbj08HcProduct.UNITGROUPCD
                ,Mbj08HcProduct.UNITGROUPNM
                ,Mbj08HcProduct.CALKBN
                ,Mbj08HcProduct.UPDDATE
                ,Mbj08HcProduct.UPDNM
                ,Mbj08HcProduct.UPDAPL
                ,Mbj08HcProduct.UPDID
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

        if (super.getModel() instanceof Mbj08HcProductVO)
        {
            // Mbj08HcProductVO取得用SQL取得
            sql = getSelectSQLMbj08HcProductVO();
        }

        return sql;

    };

    /**
     * EXEC SQL
     */
    @Override
    public String getExecString()
    {
        String sql = "";

        if (_allDelFlg)
        {
            // Mbj08HCProduct全削除用SQL取得
            sql = getAllDeleteSQLMbj08HCProduct();
        }

        return sql;

    };

    /**
     * SELECT SQL（Mbj08HcProductVO）
     */
    private String getSelectSQLMbj08HcProductVO()
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
            Mbj08HcProductVO vo = new Mbj08HcProductVO();
            vo.setHCPRODUCTCD(_condition.getHcproductcd());
            vo.setUSEBUMONCD(_condition.getUsebumoncd());
            vo.setUSEBUMONNM(_condition.getUsebumonnm());
            vo.setMEDIACLASSCD(_condition.getMediaclasscd());
            vo.setMEDIACLASSNM(_condition.getMediaclassnm());
            vo.setMEDIACD(_condition.getMediacd());
            vo.setMEDIANM(_condition.getMedianm());
            vo.setBUSINESSCLASSCD(_condition.getBusinessclasscd());
            vo.setBUSINESSCLASSNM(_condition.getBusinessclassnm());
            vo.setBUSINESSCD(_condition.getBusinesscd());
            vo.setBUSINESSNM(_condition.getBusinessnm());
            vo.setPRODUCTCD(_condition.getProductcd());
            vo.setPRODUCTNM(_condition.getProductnm());
            vo.setWEEKCD(_condition.getWeekcd());
            vo.setWEEK(_condition.getWeek());
            vo.setSIZECD(_condition.getSizecd());
            vo.setSIZE(_condition.getSize());
            vo.setUNITGROUPCD(_condition.getUnitgroupcd());
            vo.setUNITGROUPNM(_condition.getUnitgroupnm());
            vo.setCALKBN(_condition.getCalkbn());
            vo.setUPDDATE(_condition.getUpddate());
            vo.setUPDNM(_condition.getUpdnm());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDID(_condition.getUpdid());
            whereSqlStr = generateWhereByCond(vo);

        }

        orderSql.append(" ORDER BY ");
        orderSql.append(" " + Mbj08HcProduct.HCPRODUCTCD + " ");

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    };

    /**
     * ALL DELETE SQL（Mbj08HCProduct）
     */
    private String getAllDeleteSQLMbj08HCProduct()
    {
        StringBuffer deleteSql = new StringBuffer();

        deleteSql.append(" DELETE ");
        deleteSql.append(" FROM ");
        deleteSql.append(" " + getTableName() + " ");

        return deleteSql.toString();
    };

    /**
     * InsertVO
     * @param vo データ
     * @throws HAMException
     */
    public void insertVO(Mbj08HcProductVO vo) throws HAMException
    {
        // パラメータチェック
        if (vo == null)
        {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);

        try
        {
            if (!super.insert())
            {
                throw new HAMException("登録エラー", "BJ-E0002");
            }
        }
        catch(UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }

    }

    /**
     * UpdateVO
     * @param vo データ
     * @throws HAMException
     */
    public void updateVO(Mbj08HcProductVO vo) throws HAMException
    {
        // パラメータチェック
        if (vo == null)
        {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);

        try
        {
            if (!super.update())
            {
                throw new HAMException("更新エラー", "BJ-E0003");
            }
        }
        catch(UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }

    }

    /**
     * DeleteVO
     * @param vo データ
     * @throws HAMException
     */
    public void deleteVO(Mbj08HcProductVO vo) throws HAMException
    {
        // パラメータチェック
        if (vo == null)
        {
            throw new HAMException("削除エラー", "BJ-E0004");
        }
        super.setModel(vo);

        try
        {
            if (!super.remove())
            {
                throw new HAMException("削除エラー", "BJ-E0004");
            }
        }
        catch(ConcurrentUpdateException e)
        {   // 処理件数「0」の場合
            return;   // 正常とする（削除レコードなし）
        }
        catch(UpdateFailureException e)
        {   // 処理件数「2以上」の場合
            return;   // 正常とする
        }
        catch(UserException e)
        {
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
    public List<Mbj08HcProductVO> selectVO(Mbj08HcProductCondition condition) throws HAMException
    {
        // パラメータチェック
        if (condition == null)
        {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Mbj08HcProductVO());
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

    /**
     * AllDelete
     * @throws HAMException
     */
    public void allDelete() throws HAMException
    {
        _allDelFlg = true;

        try
        {
            super.exec();
        }
        catch(UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }

    }

}
