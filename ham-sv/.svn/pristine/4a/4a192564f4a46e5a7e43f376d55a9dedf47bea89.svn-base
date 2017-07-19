package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj10MediaSec;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 媒体DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/10 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class MediaListDAO extends AbstractSimpleRdbDao{


    /** データ検索条件 */
    private MediaListCondition _cond;


    /**
     * デフォルトコンストラクタ
     */
    public MediaListDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }


    /**
     * プライマリキーを返します
     *
     * @return String[] プライマリキー
     */
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * 更新日付フィールドを返します
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        // new String[] {};
        return null;
    }

    /**
     * テーブル名を返します
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return null;
    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[]{
                Mbj03Media.MEDIACD,
                Mbj03Media.MEDIANM,
                Mbj03Media.HCMEDIANM,
                Mbj03Media.DNEBIKI,
                Mbj03Media.SORTNO,
                Mbj10MediaSec.AUTHORITY
        };

    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {

        return getMediaList();
    }


    /**
     * 車種＆権限のSQL文を返します
     *
     * @return String SQL文
     */
    private String getMediaList() {

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
        sql.append(" FROM");
        sql.append(" "+ Mbj03Media.TBNAME + ",");
        sql.append(" "+ Mbj10MediaSec.TBNAME);

        sql.append(" WHERE");
        sql.append(" "+ Mbj03Media.MEDIACD + " = " + Mbj10MediaSec.MEDIACD + "(+)");
        sql.append(" AND");
        sql.append(" NOT "+ Mbj10MediaSec.AUTHORITY + " = '0'");
        sql.append(" AND");
        sql.append(" "+ Mbj10MediaSec.HAMID + " = '" + _cond.getHamid() + "'");

        sql.append(" ORDER BY");
        sql.append(" "+ Mbj03Media.SORTNO);

        return sql.toString();
    }
    /**
     * 車種＆権限の検索を行います
     *
     * @return 車種＆権限VOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<MediaListVO> findMediaList(
            MediaListCondition cond) throws HAMException {

        super.setModel(new MediaListVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
}
