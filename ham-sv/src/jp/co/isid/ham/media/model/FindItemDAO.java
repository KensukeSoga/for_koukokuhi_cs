package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu2FHmok;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu2LGKbnHmok;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
* <P>
* 費目コードを検索
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/02/19 HLC H.Watabe)<BR>
* </P>
* @author HLC H.watabe
*/
public class FindItemDAO extends AbstractSimpleRdbDao{

    /** データ検索条件 */
    private FindItemCondition _cond;

    /**
     * デフォルトコンストラクタ
     */
    public FindItemDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを返します
     *
     * @return String[] プライマリキー
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[]{
                RepaVbjaMeu2FHmok.NAIYJ
                ,RepaVbjaMeu2LGKbnHmok.GYOMKBN
                ,RepaVbjaMeu2LGKbnHmok.HMOKCD
                ,RepaVbjaMeu2LGKbnHmok.HKYMD
                ,RepaVbjaMeu2LGKbnHmok.HMOKSEQ
                ,RepaVbjaMeu2LGKbnHmok.HAISYMD
                ,RepaVbjaMeu2LGKbnHmok.KAIGAIKBN
        };
    }

    /**
     * テーブル名を返します
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        return null;
    }

    /**
     * 更新日付フィールドを返します
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

        //費目検索SQL
        return getItem();
    }

    /**
     * 費目検索のSQL文を返します
     *
     * @return String SQL文
     */
    private String getItem() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" FROM ");
        sql.append(" " + RepaVbjaMeu2FHmok.TBNAME + ", ");
        sql.append(" " + RepaVbjaMeu2LGKbnHmok.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + RepaVbjaMeu2FHmok.HMOKCD + " = " + RepaVbjaMeu2LGKbnHmok.HMOKCD +"(+) ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu2LGKbnHmok.GYOMKBN + "=  '" + _cond.getWorkFlg() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu2FHmok.NAIYJ + " IN (" + _cond.getItems() +") ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu2FHmok.HKYMD + " <= '" + _cond.getKikanFrom() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu2LGKbnHmok.HKYMD + " <= '" + _cond.getKikanFrom() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu2FHmok.HAISYMD + " >= '" + _cond.getKikanTo() + "' ");
        sql.append(" AND ");
        sql.append(" " + RepaVbjaMeu2LGKbnHmok.HAISYMD + " >= '" + _cond.getKikanTo() + "' ");

        return sql.toString();
    }

    /**
     * 費目の検索を行います
     *
     * @return キャンペーン一覧VOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<FindItemVO> findItem(FindItemCondition cond) throws HAMException {

        super.setModel(new FindItemVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
