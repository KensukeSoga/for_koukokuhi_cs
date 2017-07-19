package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj51Natural;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj38RdProgramMaterial;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ラジオ番組素材DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj38RdProgramMaterialDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Tbj38RdProgramMaterialCondition _condition = null;

    /** SqlMode */
    private enum SqlMode { DEFAULT, FIND, USED, INS, UPD };
    private SqlMode _sqlMode = SqlMode.DEFAULT;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj38RdProgramMaterialDAO() {
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
                Tbj38RdProgramMaterial.RDSEQNO
                ,Tbj38RdProgramMaterial.YEARMONTH
                ,Tbj38RdProgramMaterial.WAKUSEQ
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj38RdProgramMaterial.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        if (_sqlMode.equals(SqlMode.INS)) {
            return new String[] {
                    Tbj38RdProgramMaterial.CRTDATE
                    ,Tbj38RdProgramMaterial.UPDDATE
            };
        } else if (_sqlMode.equals(SqlMode.UPD)) {
            return new String[] {
                    Tbj38RdProgramMaterial.UPDDATE
            };
        } else {
            return new String[] { };
        }
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj38RdProgramMaterial.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj38RdProgramMaterial.RDSEQNO
                ,Tbj38RdProgramMaterial.YEARMONTH
                ,Tbj38RdProgramMaterial.WAKUSEQ
                ,Tbj38RdProgramMaterial.DAY01
                ,Tbj38RdProgramMaterial.DAY02
                ,Tbj38RdProgramMaterial.DAY03
                ,Tbj38RdProgramMaterial.DAY04
                ,Tbj38RdProgramMaterial.DAY05
                ,Tbj38RdProgramMaterial.DAY06
                ,Tbj38RdProgramMaterial.DAY07
                ,Tbj38RdProgramMaterial.DAY08
                ,Tbj38RdProgramMaterial.DAY09
                ,Tbj38RdProgramMaterial.DAY10
                ,Tbj38RdProgramMaterial.DAY11
                ,Tbj38RdProgramMaterial.DAY12
                ,Tbj38RdProgramMaterial.DAY13
                ,Tbj38RdProgramMaterial.DAY14
                ,Tbj38RdProgramMaterial.DAY15
                ,Tbj38RdProgramMaterial.DAY16
                ,Tbj38RdProgramMaterial.DAY17
                ,Tbj38RdProgramMaterial.DAY18
                ,Tbj38RdProgramMaterial.DAY19
                ,Tbj38RdProgramMaterial.DAY20
                ,Tbj38RdProgramMaterial.DAY21
                ,Tbj38RdProgramMaterial.DAY22
                ,Tbj38RdProgramMaterial.DAY23
                ,Tbj38RdProgramMaterial.DAY24
                ,Tbj38RdProgramMaterial.DAY25
                ,Tbj38RdProgramMaterial.DAY26
                ,Tbj38RdProgramMaterial.DAY27
                ,Tbj38RdProgramMaterial.DAY28
                ,Tbj38RdProgramMaterial.DAY29
                ,Tbj38RdProgramMaterial.DAY30
                ,Tbj38RdProgramMaterial.DAY31
                ,Tbj38RdProgramMaterial.CRTDATE
                ,Tbj38RdProgramMaterial.CRTNM
                ,Tbj38RdProgramMaterial.CRTAPL
                ,Tbj38RdProgramMaterial.CRTID
                ,Tbj38RdProgramMaterial.UPDDATE
                ,Tbj38RdProgramMaterial.UPDNM
                ,Tbj38RdProgramMaterial.UPDAPL
                ,Tbj38RdProgramMaterial.UPDID
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
    public String getSelectSQL() {

        String sql = "";

        if (_sqlMode.equals(SqlMode.DEFAULT)) {
            //Tbj38RdProgramMaterialVO取得SQL取得
            sql = getSelectSQLTbj38RdProgramMaterialVO();
        } else if (_sqlMode.equals(SqlMode.FIND)) {
            //ラジオ番組登録画面素材情報検索SQL取得
            sql = getSelectSQLFindRdProgramMaterial();
        } else if (_sqlMode.equals(SqlMode.USED)) {
            //素材登録画面ラジオ番組使用素材検索SQL取得
            sql = getSelectSQLFindUsedRdProgramMaterial();
        }

        return sql;
    };

    /**
     * SELECT SQL(Tbj38RdProgramMaterialVO)
     */
    private String getSelectSQLTbj38RdProgramMaterialVO() {

        StringBuffer selectSql = new StringBuffer();
        String whereSqlStr = "";
        StringBuffer orderSql = new StringBuffer();

        selectSql.append(" SELECT");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            selectSql.append((i != 0 ? " ," : " "));
            selectSql.append(getTableColumnNames()[i] + " ");
        }

        selectSql.append(" FROM");
        selectSql.append(" " + getTableName() + " ");

        if (_condition != null) {
            Tbj38RdProgramMaterialVO vo = new Tbj38RdProgramMaterialVO();
            vo.setRDSEQNO(_condition.getRdseqno());
            vo.setYEARMONTH(_condition.getYearmonth());
            vo.setWAKUSEQ(_condition.getWakuseq());
            vo.setDAY01(_condition.getDay01());
            vo.setDAY02(_condition.getDay02());
            vo.setDAY03(_condition.getDay03());
            vo.setDAY04(_condition.getDay04());
            vo.setDAY05(_condition.getDay05());
            vo.setDAY06(_condition.getDay06());
            vo.setDAY07(_condition.getDay07());
            vo.setDAY08(_condition.getDay08());
            vo.setDAY09(_condition.getDay09());
            vo.setDAY10(_condition.getDay10());
            vo.setDAY11(_condition.getDay11());
            vo.setDAY12(_condition.getDay12());
            vo.setDAY13(_condition.getDay13());
            vo.setDAY14(_condition.getDay14());
            vo.setDAY15(_condition.getDay15());
            vo.setDAY16(_condition.getDay16());
            vo.setDAY17(_condition.getDay17());
            vo.setDAY18(_condition.getDay18());
            vo.setDAY19(_condition.getDay19());
            vo.setDAY20(_condition.getDay20());
            vo.setDAY21(_condition.getDay21());
            vo.setDAY22(_condition.getDay22());
            vo.setDAY23(_condition.getDay23());
            vo.setDAY24(_condition.getDay24());
            vo.setDAY25(_condition.getDay25());
            vo.setDAY26(_condition.getDay26());
            vo.setDAY27(_condition.getDay27());
            vo.setDAY28(_condition.getDay28());
            vo.setDAY29(_condition.getDay29());
            vo.setDAY30(_condition.getDay30());
            vo.setDAY31(_condition.getDay31());
            vo.setCRTDATE(_condition.getCrtdate());
            vo.setCRTNM(_condition.getCrtnm());
            vo.setCRTAPL(_condition.getCrtapl());
            vo.setCRTID(_condition.getCrtid());
            vo.setUPDDATE(_condition.getUpddate());
            vo.setUPDNM(_condition.getUpdnm());
            vo.setUPDAPL(_condition.getUpdapl());
            vo.setUPDID(_condition.getUpdid());
            whereSqlStr = generateWhereByCond(vo);
        }

        orderSql.append(" ORDER BY");
        orderSql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        orderSql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + ",");
        orderSql.append(" " + Tbj38RdProgramMaterial.WAKUSEQ);

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    };

    /**
     * ラジオ番組登録画面素材情報検索SQLを作成する
     * @return String ラジオ番組登録画面素材情報検索SQL文
     */
    private String getSelectSQLFindRdProgramMaterial() {

        StringBuilder sql = new StringBuilder();

        sql.append(" SELECT");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == getTableColumnNames().length - 1) {
                sql.append(" " + getTableColumnNames()[i]);
            } else {
                sql.append(" " + getTableColumnNames()[i] + ",");
            }
        }

        sql.append(" FROM");
        sql.append(" " + getTableName());

        sql.append(" WHERE");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + " = " + _condition.getRdseqno());

        sql.append(" ORDER BY");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + ",");
        sql.append(" " + Tbj38RdProgramMaterial.WAKUSEQ);

        return sql.toString();
    };

    /**
     * 素材登録画面ラジオ番組使用素材検索SQLを作成する
     * @return String 素材登録画面ラジオ番組使用素材検索SQL文
     */
    private String getSelectSQLFindUsedRdProgramMaterial() {

        StringBuilder sql = new StringBuilder();

        sql.append(" SELECT");
        sql.append(" " + Tbj18SozaiKanriData.CMCD);

        sql.append(" FROM");
        sql.append(" (");

        sql.append(" SELECT");
        sql.append(" CASE " + Mbj51Natural.NO);
        sql.append(" WHEN 1 THEN " + Tbj38RdProgramMaterial.DAY01);
        sql.append(" WHEN 2 THEN " + Tbj38RdProgramMaterial.DAY02);
        sql.append(" WHEN 3 THEN " + Tbj38RdProgramMaterial.DAY03);
        sql.append(" WHEN 4 THEN " + Tbj38RdProgramMaterial.DAY04);
        sql.append(" WHEN 5 THEN " + Tbj38RdProgramMaterial.DAY05);
        sql.append(" WHEN 6 THEN " + Tbj38RdProgramMaterial.DAY06);
        sql.append(" WHEN 7 THEN " + Tbj38RdProgramMaterial.DAY07);
        sql.append(" WHEN 8 THEN " + Tbj38RdProgramMaterial.DAY08);
        sql.append(" WHEN 9 THEN " + Tbj38RdProgramMaterial.DAY09);
        sql.append(" WHEN 10 THEN " + Tbj38RdProgramMaterial.DAY10);
        sql.append(" WHEN 11 THEN " + Tbj38RdProgramMaterial.DAY11);
        sql.append(" WHEN 12 THEN " + Tbj38RdProgramMaterial.DAY12);
        sql.append(" WHEN 13 THEN " + Tbj38RdProgramMaterial.DAY13);
        sql.append(" WHEN 14 THEN " + Tbj38RdProgramMaterial.DAY14);
        sql.append(" WHEN 15 THEN " + Tbj38RdProgramMaterial.DAY15);
        sql.append(" WHEN 16 THEN " + Tbj38RdProgramMaterial.DAY16);
        sql.append(" WHEN 17 THEN " + Tbj38RdProgramMaterial.DAY17);
        sql.append(" WHEN 18 THEN " + Tbj38RdProgramMaterial.DAY18);
        sql.append(" WHEN 19 THEN " + Tbj38RdProgramMaterial.DAY19);
        sql.append(" WHEN 20 THEN " + Tbj38RdProgramMaterial.DAY20);
        sql.append(" WHEN 21 THEN " + Tbj38RdProgramMaterial.DAY21);
        sql.append(" WHEN 22 THEN " + Tbj38RdProgramMaterial.DAY22);
        sql.append(" WHEN 23 THEN " + Tbj38RdProgramMaterial.DAY23);
        sql.append(" WHEN 24 THEN " + Tbj38RdProgramMaterial.DAY24);
        sql.append(" WHEN 25 THEN " + Tbj38RdProgramMaterial.DAY25);
        sql.append(" WHEN 26 THEN " + Tbj38RdProgramMaterial.DAY26);
        sql.append(" WHEN 27 THEN " + Tbj38RdProgramMaterial.DAY27);
        sql.append(" WHEN 28 THEN " + Tbj38RdProgramMaterial.DAY28);
        sql.append(" WHEN 29 THEN " + Tbj38RdProgramMaterial.DAY29);
        sql.append(" WHEN 30 THEN " + Tbj38RdProgramMaterial.DAY30);
        sql.append(" WHEN 31 THEN " + Tbj38RdProgramMaterial.DAY31);
        sql.append(" END " + Tbj18SozaiKanriData.CMCD);

        sql.append(" FROM");
        sql.append(" " + Tbj38RdProgramMaterial.TBNAME);
        sql.append(" CROSS JOIN");
        sql.append(" " + Mbj51Natural.TBNAME);
        sql.append(" )");

        sql.append(" WHERE");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + " IS NOT NULL");

        sql.append(" GROUP BY");
        sql.append(" " + Tbj18SozaiKanriData.CMCD);

        sql.append(" ORDER BY");
        sql.append(" " + Tbj18SozaiKanriData.CMCD);

        return sql.toString();
    };

    /**
     * InsertVO
     * @param vo 登録VO
     * @throws HAMException
     */
    public void insertVO(Tbj38RdProgramMaterialVO vo) throws HAMException {

        //パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }

        super.setModel(vo);
        _sqlMode = SqlMode.INS;

        try {
            super.insert();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * UpdateVO
     * @param vo 更新VO
     * @throws HAMException
     */
    public void updateVO(Tbj38RdProgramMaterialVO vo) throws HAMException {

        //パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }

        super.setModel(vo);
        _sqlMode = SqlMode.UPD;

        try {
            super.update();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * DeleteVO
     * @param vo 削除VO
     * @throws HAMException
     */
    public void deleteVO(Tbj38RdProgramMaterialVO vo) throws HAMException {

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
     * ラジオ番組登録画面素材情報検索
     * @param condition 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj38RdProgramMaterialVO> findVO(Tbj38RdProgramMaterialCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj38RdProgramMaterialVO());
        _condition = condition;
        _sqlMode = SqlMode.FIND;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 素材登録画面ラジオ番組使用素材検索
     * @param condition 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj18SozaiKanriDataVO> findUsedRdProgramMaterial(Tbj38RdProgramMaterialCondition condition) throws HAMException {

     // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj18SozaiKanriDataVO());
        _condition = condition;
        _sqlMode = SqlMode.USED;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * SelectVO
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj38RdProgramMaterialVO> selectVO(Tbj38RdProgramMaterialCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Tbj38RdProgramMaterialVO());
        _condition = condition;
        _sqlMode = SqlMode.DEFAULT;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
