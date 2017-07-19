package jp.co.isid.ham.production.model;

import java.util.List;

import jp.co.isid.ham.common.model.Tbj43SozaiKanriListCmnOACondition;
import jp.co.isid.ham.common.model.Tbj43SozaiKanriListCmnOAVO;
import jp.co.isid.ham.integ.tbl.Tbj43SozaiKanriListCmnOA;
import jp.co.isid.ham.integ.tbl.Tbj45LogSozaiKanriListCmnOA;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
* <P>
* 素材一覧(共有OA期間)最大年月取得DAO
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2016/04/06 HLC K.Oki)<BR>
* </P>
* @author K.Oki
*/

public class GetMaterialListCmnMaxSozaiYmDAO extends AbstractSimpleRdbDao{

    /** 検索条件 */
    private Tbj43SozaiKanriListCmnOACondition _cond = null;

    /**
     * デフォルトコンストラクタ
     */
    public GetMaterialListCmnMaxSozaiYmDAO() {
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
        return new String[]{ };
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

        return findMaxSozaiYm();
    }

    /**
     * 最大年月取得SQL文を返します
     * @return String SQL文
     */
    private String findMaxSozaiYm()
    {
        StringBuilder sql = new StringBuilder();

        sql.append("SELECT");
        sql.append(" MAX(SOZAIYM)" + Tbj43SozaiKanriListCmnOA.SOZAIYM);

        sql.append(" FROM");
        sql.append(" (SELECT");
        sql.append(" MAX(" + Tbj43SozaiKanriListCmnOA.SOZAIYM + ") + 1 / 86400 " + " SOZAIYM");

        sql.append(" FROM");
        sql.append(" "+ Tbj43SozaiKanriListCmnOA.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.DCARCD + " = '" + _cond.getDcarcd() + "' AND");
        sql.append(" TO_CHAR(" + Tbj43SozaiKanriListCmnOA.SOZAIYM + ", 'YYYYMMDD') = '" + DateUtil.toString(_cond.getSozaiym()) + "' AND");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.RECKBN + " = '" + _cond.getReckbn() + "'");

        sql.append(" UNION ALL");

        sql.append(" SELECT");
        sql.append(" MAX(" + Tbj45LogSozaiKanriListCmnOA.SOZAIYM + ") + 1 / 86400 ");

        sql.append(" FROM");
        sql.append(" "+ Tbj45LogSozaiKanriListCmnOA.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.DCARCD + " = '" + _cond.getDcarcd() + "' AND");
        sql.append(" TO_CHAR(" + Tbj45LogSozaiKanriListCmnOA.SOZAIYM + ", 'YYYYMMDD') = '" + DateUtil.toString(_cond.getSozaiym()) + "' AND");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.RECKBN + " = '" + _cond.getReckbn() + "')");

        return sql.toString();
    }

    /**
     * 素材一覧(共有OA期間)最大年月取得
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj43SozaiKanriListCmnOAVO> findMaxSozaiYm(Tbj43SozaiKanriListCmnOACondition cond) throws HAMException {

        super.setModel(new Tbj43SozaiKanriListCmnOAVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
