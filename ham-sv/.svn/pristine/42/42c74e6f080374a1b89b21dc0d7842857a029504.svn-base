package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj06HcBumon;
import jp.co.isid.ham.integ.tbl.Mbj08HcProduct;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * HC商品マスタ取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/16 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCProductDAO extends AbstractRdbDao {

    FindHCProductCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindHCProductDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを取得する
     *
     * @return String[] プライマリキー
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    @Override
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
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        StringBuffer tbl = new StringBuffer();

        tbl.append(Mbj08HcProduct.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj06HcBumon.TBNAME);

        return tbl.toString();
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            sql.append(getTableColumnNames()[i]);
            if (i < getTableColumnNames().length-1) {
                sql.append(", ");
            }
        }
        sql.append(" FROM ");
        sql.append(getTableName());
        sql.append(" WHERE ");
        sql.append(Mbj06HcBumon.HCBUMONCD);
        sql.append(" IN (");
        sql.append(getHCBumonCd());
        sql.append(")");

        sql.append(" AND ");
        sql.append(Mbj08HcProduct.USEBUMONCD);
        sql.append(" = ");
        sql.append(Mbj06HcBumon.USEBUMONCD);

        // 商品コードを条件に追加
        String product = getProduct();
        if (product.length() > 0)
        {
            sql.append(" AND ");
            sql.append(Mbj08HcProduct.PRODUCTCD);
            sql.append(" IN (");
            sql.append(product);
            sql.append(")");
        }

        sql.append(" ORDER BY ");
        sql.append(Mbj08HcProduct.MEDIACLASSCD);
        sql.append(", ");
        sql.append(Mbj08HcProduct.MEDIACD);
        sql.append(", ");
        sql.append(Mbj08HcProduct.BUSINESSCLASSCD);
        sql.append(", ");
        sql.append(Mbj08HcProduct.BUSINESSCD);
        sql.append(", ");
        sql.append(Mbj08HcProduct.PRODUCTCD);
        sql.append(", ");
        sql.append(Mbj08HcProduct.WEEKCD);
        sql.append(", ");
        sql.append(Mbj08HcProduct.SIZECD);
        sql.append(", ");
        sql.append(Mbj08HcProduct.UNITGROUPCD);

        return sql.toString();
    }

    /**
     * カンマ区切りのHC部門コードを取得します
     *
     * @return カンマ区切りのHC部門コード
     */
    private String getHCBumonCd() {
        StringBuffer hcbumon = new StringBuffer();

        //HC部門コードをカンマ区切りで連結
        for (int i = 0; i < _condition.getHCBumonCd().size(); i++) {
            hcbumon.append("'");
            hcbumon.append(_condition.getHCBumonCd().get(i));
            hcbumon.append("'");
            if (i < _condition.getHCBumonCd().size()-1) {
                hcbumon.append(", ");
            }
        }

        return hcbumon.toString();
    }


    /**
     * カンマ区切りの商品コードを取得します
     *
     * @return カンマ区切りの商品コード
     */
    private String getProduct() {
        StringBuffer product = new StringBuffer();

        //商品コードをカンマ区切りで連結
        for (int i = 0; i < _condition.getProductCd().size(); i++) {
            product.append("'");
            product.append(_condition.getProductCd().get(i));
            product.append("'");
            if (i < _condition.getProductCd().size()-1) {
                product.append(", ");
            }
        }

        return product.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindHCProductVO> selectVO(FindHCProductCondition condition) throws HAMException {
        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindHCProductVO());
        try
        {
            _condition = condition;
            return (List<FindHCProductVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
