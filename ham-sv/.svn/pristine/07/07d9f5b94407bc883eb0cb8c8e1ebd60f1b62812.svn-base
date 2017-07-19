package jp.co.isid.ham.billing.model;

import java.util.List;
import jp.co.isid.ham.common.model.Mbj27MediaProductVO;
import jp.co.isid.ham.integ.tbl.Mbj08HcProduct;
import jp.co.isid.ham.integ.tbl.Mbj27MediaProduct;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * 媒体・商品紐付けマスタ取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/19 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindMediaProductDAO extends AbstractRdbDao {

    FindMediaProductCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindMediaProductDAO() {
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
                Mbj27MediaProduct.PHASE
                ,Mbj27MediaProduct.DCARCD
                ,Mbj27MediaProduct.MEDIACD
                ,Mbj27MediaProduct.HCBUMONCD
                ,Mbj27MediaProduct.PRODUCTCD
                ,Mbj08HcProduct.HCPRODUCTCD
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

        tbl.append(Mbj27MediaProduct.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj08HcProduct.TBNAME);

        return tbl.toString();
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    @Override
    public String getTimeStampKeyName() {
        return Mbj27MediaProduct.UPDDATE;
    }

    /**
     * SELECT SQL
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
        sql.append(Mbj27MediaProduct.PRODUCTCD);
        sql.append(" = ");
        sql.append(Mbj08HcProduct.PRODUCTCD);

        sql.append(" AND ");
        sql.append(Mbj27MediaProduct.PHASE);
        sql.append(" = ");
        sql.append(_condition.getPhase());

        String dcarcd = getDCarCd();
        if (dcarcd.length() > 0) {
            sql.append(" AND ");
            sql.append(Mbj27MediaProduct.DCARCD);
            sql.append(" IN (");
            sql.append(dcarcd);
            sql.append(")");
        }

        String mediacd = getMediaCd();
        if (mediacd.length() > 0) {
            sql.append(" AND ");
            sql.append(Mbj27MediaProduct.MEDIACD);
            sql.append(" IN (");
            sql.append(mediacd);
            sql.append(")");
        }

        return sql.toString();
    }

    /**
     * カンマ区切りの電通車種コードを取得します
     *
     * @return カンマ区切りの電通車種コード
     */
    private String getDCarCd() {
        StringBuffer sql = new StringBuffer();

        //電通車種コードをカンマ区切りで連結
        for (int i = 0; i < _condition.getDCarCd().size(); i++) {
            sql.append("'");
            sql.append(_condition.getDCarCd().get(i));
            sql.append("'");
            if (i < _condition.getDCarCd().size()-1) {
                sql.append(", ");
            }
        }

        return sql.toString();
    }

    /**
     * カンマ区切りの媒体コードを取得します
     *
     * @return カンマ区切りの媒体コード
     */
    private String getMediaCd() {
        StringBuffer sql = new StringBuffer();

        //媒体コードをカンマ区切りで連結
        for (int i = 0; i < _condition.getMediaCd().size(); i++) {
            sql.append("'");
            sql.append(_condition.getMediaCd().get(i));
            sql.append("'");
            if (i < _condition.getMediaCd().size()-1) {
                sql.append(", ");
            }
        }

        return sql.toString();
    }

    /**
     * SelectVO
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindMediaProductVO> selectVO(FindMediaProductCondition condition) throws HAMException {
        // パラメータチェック
        if (condition == null)
        {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Mbj27MediaProductVO());
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
