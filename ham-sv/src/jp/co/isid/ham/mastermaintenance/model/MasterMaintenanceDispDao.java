package jp.co.isid.ham.mastermaintenance.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import jp.co.isid.ham.common.model.Vbj01AccUserVO;
import jp.co.isid.ham.integ.tbl.Mbj02User;
import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj08HcProduct;
import jp.co.isid.ham.integ.tbl.Mbj10MediaSec;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.Mbj23CarTanto;
import jp.co.isid.ham.integ.tbl.Mbj33FunctionControl;
import jp.co.isid.ham.integ.tbl.Mbj34FunctionControlItem;
import jp.co.isid.ham.integ.tbl.Mbj42Security;
import jp.co.isid.ham.integ.tbl.Mbj43SecurityItem;
import jp.co.isid.ham.integ.tbl.Mbj52SzTntUser;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu20MsMzBt;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu07SikKrSprd;
import jp.co.isid.ham.integ.tbl.T_SecurityGroup;
import jp.co.isid.ham.integ.tbl.T_TransactionSecurity;
import jp.co.isid.ham.integ.tbl.T_UserInfo;
import jp.co.isid.ham.integ.tbl.Tbj29LoginUser;
import jp.co.isid.ham.integ.tbl.Vbj01AccUser;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;
import jp.co.isid.nj.model.AbstractModel;
/**
 * <P>
 * マスタメンテナンス表示用DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/04 森)<BR>
 * ・HDX対応(2016/02/16 HLC K.Oki)<BR>
 * </P>
 * @author 森
 */
public class MasterMaintenanceDispDao extends AbstractRdbDao
{
    /** データ検索条件 */
    private MasterMaintenanceAuthoritySpreadCondition _condCarAuthoritySpread;
    private MasterMaintenanceAuthoritySpreadCondition _condMediaAuthoritySpread;
    private MasterMaintenanceFunctionControlSpreadCondition _condFunctionControlSpread;
    private MasterMaintenanceSecuritySpreadCondition _condSecuritySpread;
    private MasterMaintenanceMEU20MSMZBTCondition _condMEU20MSMZBT;
    private MasterMaintenanceMEU07SIKKRSPRDCondition _condMEU07SIKKRSPRD;
    private MasterMaintenanceMEU07SIKKRSPRDLikeCondition _likeCondMEU07SIKKRSPRD;
    private MasterMaintenanceAccUserCondition _condAccUser;
    private MasterMaintenanceAccUserLikeCondition _likeCondAccUser;

    /**
     * デフォルトコンストラクタ
     */
    public MasterMaintenanceDispDao()
    {
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
    public String[] getPrimryKeyNames()
    {
        return null;
    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames()
    {
        return null;
    }

    /**
     * テーブル名を返します
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName()
    {
        return null;
    }

    /**
     * 更新日付フィールドを返します
     *
     * @return String 更新日付フィールド
     */
    @Override
    public String getTimeStampKeyName()
    {
        return null;
    }

    /**
     * SQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL()
    {
        String sql = "";

        if (super.getModel() instanceof MasterMaintenanceUserSpreadVO)
        {
            // UserSpreadVO取得用SQL取得
            sql = getSelectSQLUserSpreadVO();
        }
        else if (super.getModel() instanceof MasterMaintenanceCarAuthoritySpreadVO)
        {
            // CarAuthoritySpreadVO取得用SQL取得
            sql = getSelectSQLCarAuthoritySpreadVO();
        }
        else if (super.getModel() instanceof MasterMaintenanceMediaAuthoritySpreadVO)
        {
            // MediaAuthoritySpreadVO取得用SQL取得
            sql = getSelectSQLMediaAuthoritySpreadVO();
        }
        else if (super.getModel() instanceof MasterMaintenanceCarUserSpreadVO)
        {
            // CarUserSpreadVO取得用SQL取得
            sql = getSelectSQLCarUserSpreadVO();
        }
        else if (super.getModel() instanceof MasterMaintenanceHCProductSpreadVO)
        {
            // HCProductSpreadVO取得用SQL取得
            sql = getSelectSQLHCProductSpreadVO();
        }
        else if (super.getModel() instanceof MasterMaintenanceFunctionControlSpreadVO)
        {
            // FunctionControlSpreadVO取得用SQL取得
            sql = getSelectSQLFunctionControlSpreadVO();
        }
        else if (super.getModel() instanceof MasterMaintenanceSecuritySpreadVO)
        {
            // SecuritySpreadVO取得用SQL取得
            sql = getSelectSQLSecuritySpreadVO();
        }
        else if (super.getModel() instanceof MasterMaintenanceMEU20MSMZBTVO)
        {
            // MEU20MSMZBTVO取得用SQL取得
            sql = getSelectSQLMEU20MSMZBTVO();
        }
        else if ((super.getModel() instanceof MasterMaintenanceMEU07SIKKRSPRDVO) && (_condMEU07SIKKRSPRD != null))
        {
            // MEU07SIKKRSPRDVO取得用SQL取得
            sql = getSelectSQLMEU07SIKKRSPRDVO();
        }
        else if ((super.getModel() instanceof MasterMaintenanceMEU07SIKKRSPRDVO) && (_likeCondMEU07SIKKRSPRD != null))
        {
            // MEU07SIKKRSPRDVO取得用SQL取得（含む検索）
            sql = getSelectSQLLikeMEU07SIKKRSPRDVO();
        }
        else if ((super.getModel() instanceof Vbj01AccUserVO) && (_condAccUser != null))
        {
            // Vbj01AccUserVO取得用SQL取得
            sql = getSelectSQLVbj01AccUserVO();
        }
        else if ((super.getModel() instanceof Vbj01AccUserVO) && (_likeCondAccUser != null))
        {
            // Vbj01AccUserVO取得用SQL取得（含む検索）
            sql = getSelectSQLLikeVbj01AccUserVO();
        }
        /* 2016/02/16 HDX対応 HLC K.Oki ADD Start */
        else if ((super.getModel() instanceof MasterMaintenanceCarUserSozaiSpreadVO))
        {
            // CarUserSozaiSpreadVO取得用SQL取得
            sql = getSelectSQLCarUserSozaiSpreadVO();
        }
        else if ((super.getModel() instanceof MasterMaintenanceHCHMSecGrpUserSpreadVO))
        {
            // CarUserMediaSpreadVO取得用SQL取得
            sql = getSelectSQLHCHMSecGrpUserSpreadVO();
        }
        /* 2016/02/16 HDX対応 HLC K.Oki ADD End */

        return sql;
    }

    /**
     * UserSpreadVO取得のSQL文を返します
     *
     * @return String SQL文
     */
    private String getSelectSQLUserSpreadVO()
    {
        StringBuffer selectSql = new StringBuffer();

        selectSql.append(String.format("SELECT %s.%s AS %s ",Mbj02User.TBNAME,Mbj02User.HAMID,"HAMID"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj02User.TBNAME,Mbj02User.USERNAME1,"USERNAME1"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj02User.TBNAME,Mbj02User.USERNAME2,"USERNAME2"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Tbj29LoginUser.TBNAME,Tbj29LoginUser.HAMID,"LOGINHAMID"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj02User.TBNAME,Mbj02User.USERTYPE,"USERTYPE"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj02User.TBNAME,Mbj02User.UPDDATE,"UPDDATE"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj02User.TBNAME,Mbj02User.UPDNM,"UPDNM"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj02User.TBNAME,Mbj02User.UPDAPL,"UPDAPL"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj02User.TBNAME,Mbj02User.UPDID,"UPDID"));
        selectSql.append(String.format("FROM %s ",Mbj02User.TBNAME));
        selectSql.append(String.format("    ,%s ",Tbj29LoginUser.TBNAME));
        selectSql.append(String.format("WHERE %s.%s = %s.%s(+) ",Mbj02User.TBNAME,Mbj02User.HAMID,Tbj29LoginUser.TBNAME,Tbj29LoginUser.HAMID));
        selectSql.append(String.format("ORDER BY %s.%s ",Mbj02User.TBNAME,Mbj02User.HAMID));

        return selectSql.toString();
    }

    /**
     * CarAuthoritySpreadVO取得のSQL文を返します
     *
     * @return String SQL文
     */
    private String getSelectSQLCarAuthoritySpreadVO()
    {
        StringBuffer selectSql = new StringBuffer();

        selectSql.append(String.format("SELECT '%s' AS %s ","0","SECTYPE"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","HAMID","HAMID"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D1","DCARCD","DCARCD"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D1","SORTNO","SORTNO"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D1","CARNM","CARNM"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","AUTHORITY","AUTHORITY"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDDATE","UPDDATE"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDNM","UPDNM"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDAPL","UPDAPL"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDID","UPDID"));
        selectSql.append(String.format("FROM ( "));
        selectSql.append(String.format("        SELECT %s.%s AS %s ",Mbj05Car.TBNAME,Mbj05Car.DCARCD,"DCARCD"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj05Car.TBNAME,Mbj05Car.CARNM,"CARNM"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj05Car.TBNAME,Mbj05Car.SORTNO,"SORTNO"));
        selectSql.append(String.format("        FROM %s ",Mbj05Car.TBNAME));
        selectSql.append(String.format("     ) %s ","D1"));
        selectSql.append(String.format("     FULL JOIN "));
        selectSql.append(String.format("     ( "));
        selectSql.append(String.format("        SELECT %s.%s AS %s ",Mbj11CarSec.TBNAME,Mbj11CarSec.SECTYPE,"SECTYPE"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj11CarSec.TBNAME,Mbj11CarSec.HAMID,"HAMID"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj11CarSec.TBNAME,Mbj11CarSec.DCARCD,"DCARCD"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj11CarSec.TBNAME,Mbj11CarSec.AUTHORITY,"AUTHORITY"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj11CarSec.TBNAME,Mbj11CarSec.UPDDATE,"UPDDATE"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj11CarSec.TBNAME,Mbj11CarSec.UPDNM,"UPDNM"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj11CarSec.TBNAME,Mbj11CarSec.UPDAPL,"UPDAPL"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj11CarSec.TBNAME,Mbj11CarSec.UPDID,"UPDID"));
        selectSql.append(String.format("        FROM %s ",Mbj11CarSec.TBNAME));
        selectSql.append(String.format("        WHERE %s.%s = '%s' ",Mbj11CarSec.TBNAME,Mbj11CarSec.HAMID,_condCarAuthoritySpread.getHAMID()));
        selectSql.append(String.format("        AND   %s.%s = '%s' ",Mbj11CarSec.TBNAME,Mbj11CarSec.SECTYPE,"0"));
        selectSql.append(String.format("     ) %s ","D2"));
        selectSql.append(String.format("ON %s.%s = %s.%s ","D1","DCARCD","D2","DCARCD"));
        selectSql.append(String.format("UNION ALL "));
        selectSql.append(String.format("SELECT '%s' AS %s ","1","SECTYPE"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","HAMID","HAMID"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D1","DCARCD","DCARCD"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D1","SORTNO","SORTNO"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D1","CARNM","CARNM"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","AUTHORITY","AUTHORITY"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDDATE","UPDDATE"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDNM","UPDNM"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDAPL","UPDAPL"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDID","UPDID"));
        selectSql.append(String.format("FROM ( "));
        selectSql.append(String.format("        SELECT %s.%s AS %s ",Mbj05Car.TBNAME,Mbj05Car.DCARCD,"DCARCD"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj05Car.TBNAME,Mbj05Car.CARNM,"CARNM"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj05Car.TBNAME,Mbj05Car.SORTNO,"SORTNO"));
        selectSql.append(String.format("        FROM %s ",Mbj05Car.TBNAME));
        selectSql.append(String.format("     ) %s ","D1"));
        selectSql.append(String.format("     FULL JOIN "));
        selectSql.append(String.format("     ( "));
        selectSql.append(String.format("        SELECT %s.%s AS %s ",Mbj11CarSec.TBNAME,Mbj11CarSec.SECTYPE,"SECTYPE"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj11CarSec.TBNAME,Mbj11CarSec.HAMID,"HAMID"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj11CarSec.TBNAME,Mbj11CarSec.DCARCD,"DCARCD"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj11CarSec.TBNAME,Mbj11CarSec.AUTHORITY,"AUTHORITY"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj11CarSec.TBNAME,Mbj11CarSec.UPDDATE,"UPDDATE"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj11CarSec.TBNAME,Mbj11CarSec.UPDNM,"UPDNM"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj11CarSec.TBNAME,Mbj11CarSec.UPDAPL,"UPDAPL"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj11CarSec.TBNAME,Mbj11CarSec.UPDID,"UPDID"));
        selectSql.append(String.format("        FROM %s ",Mbj11CarSec.TBNAME));
        selectSql.append(String.format("        WHERE %s.%s = '%s' ",Mbj11CarSec.TBNAME,Mbj11CarSec.HAMID,_condCarAuthoritySpread.getHAMID()));
        selectSql.append(String.format("        AND   %s.%s = '%s' ",Mbj11CarSec.TBNAME,Mbj11CarSec.SECTYPE,"1"));
        selectSql.append(String.format("     ) %s ","D2"));
        selectSql.append(String.format("ON %s.%s = %s.%s ","D1","DCARCD","D2","DCARCD"));
        selectSql.append(String.format("ORDER BY %s ","SECTYPE"));
        selectSql.append(String.format("        ,%s ","SORTNO"));
        selectSql.append(String.format("        ,%s ","DCARCD"));

        return selectSql.toString();
    }

    /**
     * MediaAuthoritySpreadVO取得のSQL文を返します
     *
     * @return String SQL文
     */
    private String getSelectSQLMediaAuthoritySpreadVO()
    {
        StringBuffer selectSql = new StringBuffer();

        selectSql.append(String.format("SELECT %s.%s AS %s ","D2","HAMID","HAMID"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D1","MEDIACD","MEDIACD"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D1","MEDIANM","MEDIANM"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","AUTHORITY","AUTHORITY"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDDATE","UPDDATE"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDNM","UPDNM"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDAPL","UPDAPL"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDID","UPDID"));
        selectSql.append(String.format("FROM ( "));
        selectSql.append(String.format("       SELECT %s.%s AS %s ",Mbj03Media.TBNAME,Mbj03Media.MEDIACD,"MEDIACD"));
        selectSql.append(String.format("             ,%s.%s AS %s ",Mbj03Media.TBNAME,Mbj03Media.MEDIANM,"MEDIANM"));
        selectSql.append(String.format("             ,%s.%s AS %s ",Mbj03Media.TBNAME,Mbj03Media.SORTNO,"SORTNO"));
        selectSql.append(String.format("       FROM %s ",Mbj03Media.TBNAME));
        selectSql.append(String.format("     ) %s ","D1"));
        selectSql.append(String.format("     FULL JOIN "));
        selectSql.append(String.format("     ( "));
        selectSql.append(String.format("       SELECT %s.%s AS %s ",Mbj10MediaSec.TBNAME,Mbj10MediaSec.HAMID,"HAMID"));
        selectSql.append(String.format("             ,%s.%s AS %s ",Mbj10MediaSec.TBNAME,Mbj10MediaSec.MEDIACD,"MEDIACD"));
        selectSql.append(String.format("             ,%s.%s AS %s ",Mbj10MediaSec.TBNAME,Mbj10MediaSec.AUTHORITY,"AUTHORITY"));
        selectSql.append(String.format("             ,%s.%s AS %s ",Mbj10MediaSec.TBNAME,Mbj10MediaSec.UPDDATE,"UPDDATE"));
        selectSql.append(String.format("             ,%s.%s AS %s ",Mbj10MediaSec.TBNAME,Mbj10MediaSec.UPDNM,"UPDNM"));
        selectSql.append(String.format("             ,%s.%s AS %s ",Mbj10MediaSec.TBNAME,Mbj10MediaSec.UPDAPL,"UPDAPL"));
        selectSql.append(String.format("             ,%s.%s AS %s ",Mbj10MediaSec.TBNAME,Mbj10MediaSec.UPDID,"UPDID"));
        selectSql.append(String.format("       FROM %s ",Mbj10MediaSec.TBNAME));
        selectSql.append(String.format("       WHERE %s.%s = '%s' ",Mbj10MediaSec.TBNAME,Mbj10MediaSec.HAMID,_condMediaAuthoritySpread.getHAMID()));
        selectSql.append(String.format("     ) %s ","D2"));
        selectSql.append(String.format("ON %s.%s = %s.%s ","D1","MEDIACD","D2","MEDIACD"));
        selectSql.append(String.format("ORDER BY %s.%s ","D1","SORTNO"));
        selectSql.append(String.format("        ,%s.%s ","D1","MEDIACD"));

        return selectSql.toString();
    }

    /**
     * CarUserSpreadVO取得のSQL文を返します
     *
     * @return String SQL文
     */
    private String getSelectSQLCarUserSpreadVO()
    {
        StringBuffer selectSql = new StringBuffer();

        selectSql.append(String.format("SELECT %s.%s AS %s ","D1","DCARCD","DCARCD"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D1","CARNM","CARNM"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D1","SORTNO","SORTNO"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","MEDIATANTO","MEDIATANTO"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","CRTANTO","CRTANTO"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDDATE","UPDDATE"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDNM","UPDNM"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDAPL","UPDAPL"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDID","UPDID"));
        selectSql.append(String.format("FROM ( "));
        selectSql.append(String.format("       SELECT %s.%s AS %s ",Mbj05Car.TBNAME,Mbj05Car.DCARCD,"DCARCD"));
        selectSql.append(String.format("             ,%s.%s AS %s ",Mbj05Car.TBNAME,Mbj05Car.CARNM,"CARNM"));
        selectSql.append(String.format("             ,%s.%s AS %s ",Mbj05Car.TBNAME,Mbj05Car.SORTNO,"SORTNO"));
        selectSql.append(String.format("       FROM %s ",Mbj05Car.TBNAME));
        selectSql.append(String.format("     ) %s ","D1"));
        selectSql.append(String.format("     FULL JOIN "));
        selectSql.append(String.format("     ( "));
        selectSql.append(String.format("       SELECT %s.%s AS %s ",Mbj23CarTanto.TBNAME,Mbj23CarTanto.DCARCD,"DCARCD"));
        selectSql.append(String.format("             ,%s.%s AS %s ",Mbj23CarTanto.TBNAME,Mbj23CarTanto.MEDIATANTO,"MEDIATANTO"));
        selectSql.append(String.format("             ,%s.%s AS %s ",Mbj23CarTanto.TBNAME,Mbj23CarTanto.CRTANTO,"CRTANTO"));
        selectSql.append(String.format("             ,%s.%s AS %s ",Mbj23CarTanto.TBNAME,Mbj23CarTanto.UPDDATE,"UPDDATE"));
        selectSql.append(String.format("             ,%s.%s AS %s ",Mbj23CarTanto.TBNAME,Mbj23CarTanto.UPDNM,"UPDNM"));
        selectSql.append(String.format("             ,%s.%s AS %s ",Mbj23CarTanto.TBNAME,Mbj23CarTanto.UPDAPL,"UPDAPL"));
        selectSql.append(String.format("             ,%s.%s AS %s ",Mbj23CarTanto.TBNAME,Mbj23CarTanto.UPDID,"UPDID"));
        selectSql.append(String.format("       FROM %s ",Mbj23CarTanto.TBNAME));
        selectSql.append(String.format("     ) %s ","D2"));
        selectSql.append(String.format("ON %s.%s = %s.%s ","D1","DCARCD","D2","DCARCD"));
        selectSql.append(String.format("ORDER BY %s.%s ","D1","SORTNO"));
        selectSql.append(String.format("        ,%s.%s ","D1","DCARCD"));

        return selectSql.toString();
    }

    /**
     * HCProductSpreadVO取得のSQL文を返します
     *
     * @return String SQL文
     */
    private String getSelectSQLHCProductSpreadVO()
    {
        StringBuffer selectSql = new StringBuffer();

        selectSql.append(String.format("SELECT %s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.HCPRODUCTCD,"HCPRODUCTCD"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.USEBUMONCD,"USEBUMONCD"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.USEBUMONNM,"USEBUMONNM"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.MEDIACLASSCD,"MEDIACLASSCD"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.MEDIACLASSNM,"MEDIACLASSNM"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.MEDIACD,"MEDIACD"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.MEDIANM,"MEDIANM"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.BUSINESSCLASSCD,"BUSINESSCLASSCD"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.BUSINESSCLASSNM,"BUSINESSCLASSNM"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.BUSINESSCD,"BUSINESSCD"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.BUSINESSNM,"BUSINESSNM"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.PRODUCTCD,"PRODUCTCD"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.PRODUCTNM,"PRODUCTNM"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.WEEKCD,"WEEKCD"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.WEEK,"WEEK"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.SIZECD,"SIZECD"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.SIZE,"SIZEDATA"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.UNITGROUPCD,"UNITGROUPCD"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.UNITGROUPNM,"UNITGROUPNM"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.CALKBN,"CALKBN"));
        selectSql.append(String.format("      ,CASE WHEN %s.%s IS NULL ","CODEMST","CODENAME"));
        selectSql.append(String.format("            THEN %s.%s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.CALKBN));
        selectSql.append(String.format("            ELSE %s.%s ","CODEMST","CODENAME"));
        selectSql.append(String.format("       END AS %s ","CALKBNNAME"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.UPDDATE,"UPDDATE"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.UPDNM,"UPDNM"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.UPDAPL,"UPDAPL"));
        selectSql.append(String.format("      ,%s.%s AS %s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.UPDID,"UPDID"));
        selectSql.append(String.format("FROM %s ",Mbj08HcProduct.TBNAME));
        selectSql.append(String.format("    ,( "));
        selectSql.append(String.format("        SELECT %s.%s AS %s ",Mbj12Code.TBNAME,Mbj12Code.KEYCODE,"KEYCODE"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj12Code.TBNAME,Mbj12Code.CODENAME,"CODENAME"));
        selectSql.append(String.format("        FROM %s ",Mbj12Code.TBNAME));
        selectSql.append(String.format("        WHERE %s.%s = '%s' ",Mbj12Code.TBNAME,Mbj12Code.CODETYPE,"15"));
        selectSql.append(String.format("     ) %s ","CODEMST"));
        selectSql.append(String.format("WHERE %s.%s = %s.%s(+) ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.CALKBN,"CODEMST","KEYCODE"));
        selectSql.append(String.format("ORDER BY %s.%s ",Mbj08HcProduct.TBNAME,Mbj08HcProduct.HCPRODUCTCD));

        return selectSql.toString();
    }

    /**
     * FunctionControlSpreadVO取得のSQL文を返します
     *
     * @return String SQL文
     */
    private String getSelectSQLFunctionControlSpreadVO()
    {
        StringBuffer selectSql = new StringBuffer();

        selectSql.append(String.format("SELECT %s.%s AS %s ","D2","HAMID","HAMID"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D1","FUNCCD","FUNCCD"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D1","FUNCNM","FUNCNM"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D1","FUNCTYPE","FUNCTYPE"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","CONTROL","CONTROL"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D1","DEFAULTCONTROL","DEFAULTCONTROL"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D1","ITEMTYPE","ITEMTYPE"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDDATE","UPDDATE"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDNM","UPDNM"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDAPL","UPDAPL"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDID","UPDID"));
        selectSql.append(String.format("FROM ( "));
        selectSql.append(String.format("        SELECT %s.%s AS %s ",Mbj34FunctionControlItem.TBNAME,Mbj34FunctionControlItem.FUNCCD,"FUNCCD"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj34FunctionControlItem.TBNAME,Mbj34FunctionControlItem.FUNCTYPE,"FUNCTYPE"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj34FunctionControlItem.TBNAME,Mbj34FunctionControlItem.FUNCNM,"FUNCNM"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj34FunctionControlItem.TBNAME,Mbj34FunctionControlItem.DEFAULTCONTROL,"DEFAULTCONTROL"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj34FunctionControlItem.TBNAME,Mbj34FunctionControlItem.ITEMTYPE,"ITEMTYPE"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj34FunctionControlItem.TBNAME,Mbj34FunctionControlItem.SORTNO,"SORTNO"));
        selectSql.append(String.format("        FROM %s ",Mbj34FunctionControlItem.TBNAME));
        selectSql.append(String.format("     ) %s ","D1"));
        selectSql.append(String.format("     FULL JOIN "));
        selectSql.append(String.format("     ( "));
        selectSql.append(String.format("        SELECT %s.%s AS %s ",Mbj33FunctionControl.TBNAME,Mbj33FunctionControl.HAMID,"HAMID"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj33FunctionControl.TBNAME,Mbj33FunctionControl.FUNCCD,"FUNCCD"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj33FunctionControl.TBNAME,Mbj33FunctionControl.CONTROL,"CONTROL"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj33FunctionControl.TBNAME,Mbj33FunctionControl.UPDDATE,"UPDDATE"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj33FunctionControl.TBNAME,Mbj33FunctionControl.UPDNM,"UPDNM"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj33FunctionControl.TBNAME,Mbj33FunctionControl.UPDAPL,"UPDAPL"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj33FunctionControl.TBNAME,Mbj33FunctionControl.UPDID,"UPDID"));
        selectSql.append(String.format("        FROM %s ",Mbj33FunctionControl.TBNAME));
        selectSql.append(String.format("        WHERE %s.%s = '%s' ",Mbj33FunctionControl.TBNAME,Mbj33FunctionControl.HAMID,_condFunctionControlSpread.getHAMID()));
        selectSql.append(String.format("     ) %s ","D2"));
        selectSql.append(String.format("ON %s.%s = %s.%s ","D1","FUNCCD","D2","FUNCCD"));
        selectSql.append(String.format("ORDER BY %s.%s ","D1","SORTNO"));
        selectSql.append(String.format("        ,%s.%s ","D1","FUNCCD"));

        return selectSql.toString();
    }

    /**
     * SecuritySpreadVO取得のSQL文を返します
     *
     * @return String SQL文
     */
    private String getSelectSQLSecuritySpreadVO()
    {
        StringBuffer selectSql = new StringBuffer();

        selectSql.append(String.format("SELECT %s.%s AS %s ","D2","HAMID","HAMID"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D1","SECURITYCD","SECURITYCD"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D1","SECURITYTYPE","SECURITYTYPE"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D1","SECURITYNM","SECURITYNM"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDATE_","UPDATE_"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","CHECK_","CHECK_"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","REFERENCE","REFERENCE"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D1","ITEMTYPE","ITEMTYPE"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDDATE","UPDDATE"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDNM","UPDNM"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDAPL","UPDAPL"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D2","UPDID","UPDID"));
        selectSql.append(String.format("FROM ( "));
        selectSql.append(String.format("        SELECT %s.%s AS %s ",Mbj43SecurityItem.TBNAME,Mbj43SecurityItem.SECURITYCD,"SECURITYCD"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj43SecurityItem.TBNAME,Mbj43SecurityItem.SECURITYTYPE,"SECURITYTYPE"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj43SecurityItem.TBNAME,Mbj43SecurityItem.SECURITYNM,"SECURITYNM"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj43SecurityItem.TBNAME,Mbj43SecurityItem.ITEMTYPE,"ITEMTYPE"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj43SecurityItem.TBNAME,Mbj43SecurityItem.SORTNO,"SORTNO"));
        selectSql.append(String.format("        FROM %s ",Mbj43SecurityItem.TBNAME));
        selectSql.append(String.format("     ) %s ","D1"));
        selectSql.append(String.format("     FULL JOIN "));
        selectSql.append(String.format("     ( "));
        selectSql.append(String.format("        SELECT %s.%s AS %s ",Mbj42Security.TBNAME,Mbj42Security.HAMID,"HAMID"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj42Security.TBNAME,Mbj42Security.SECURITYCD,"SECURITYCD"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj42Security.TBNAME,Mbj42Security.UPDATE,"UPDATE_"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj42Security.TBNAME,Mbj42Security.CHECK,"CHECK_"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj42Security.TBNAME,Mbj42Security.REFERENCE,"REFERENCE"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj42Security.TBNAME,Mbj42Security.UPDDATE,"UPDDATE"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj42Security.TBNAME,Mbj42Security.UPDNM,"UPDNM"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj42Security.TBNAME,Mbj42Security.UPDAPL,"UPDAPL"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Mbj42Security.TBNAME,Mbj42Security.UPDID,"UPDID"));
        selectSql.append(String.format("        FROM %s ",Mbj42Security.TBNAME));
        selectSql.append(String.format("        WHERE %s.%s = '%s' ",Mbj42Security.TBNAME,Mbj42Security.HAMID,_condSecuritySpread.getHAMID()));
        selectSql.append(String.format("     ) %s ","D2"));
        selectSql.append(String.format("ON %s.%s = %s.%s ","D1","SECURITYCD","D2","SECURITYCD"));
        selectSql.append(String.format("ORDER BY %s.%s ","D1","SORTNO"));
        selectSql.append(String.format("        ,%s.%s ","D1","SECURITYCD"));

        return selectSql.toString();
    }

    /**
     * MEU20MSMZBTVO取得のSQL文を返します
     *
     * @return String SQL文
     */
    private String getSelectSQLMEU20MSMZBTVO()
    {
        StringBuffer selectSql = new StringBuffer();

        selectSql.append(String.format("SELECT %s.%s AS %s ",RepaVbjaMeu20MsMzBt.TBNAME,RepaVbjaMeu20MsMzBt.SZKBN,"SZKBN"));
        selectSql.append(String.format("      ,%s.%s AS %s ",RepaVbjaMeu20MsMzBt.TBNAME,RepaVbjaMeu20MsMzBt.SINZATSUBTAICD,"SINZATSUBTAICD"));
        selectSql.append(String.format("      ,%s.%s AS %s ",RepaVbjaMeu20MsMzBt.TBNAME,RepaVbjaMeu20MsMzBt.KBANCD,"KBANCD"));
        selectSql.append(String.format("      ,%s.%s AS %s ",RepaVbjaMeu20MsMzBt.TBNAME,RepaVbjaMeu20MsMzBt.SINZATSUBTAINMJ,"SINZATSUBTAINMJ"));
        selectSql.append(String.format("      ,%s.%s AS %s ",RepaVbjaMeu20MsMzBt.TBNAME,RepaVbjaMeu20MsMzBt.SINZATSUBTAINMK,"SINZATSUBTAINMK"));
        selectSql.append(String.format("FROM %s ",RepaVbjaMeu20MsMzBt.TBNAME));

        if ((_condMEU20MSMZBT != null) &&
           (_condMEU20MSMZBT.getSZKBN() != null) &&
           (!_condMEU20MSMZBT.getSZKBN().isEmpty()))
        {
            selectSql.append(String.format("WHERE %s.%s = '%s' ",RepaVbjaMeu20MsMzBt.TBNAME,RepaVbjaMeu20MsMzBt.SZKBN,_condMEU20MSMZBT.getSZKBN()));
        }
        selectSql.append(String.format("ORDER BY %s.%s ",RepaVbjaMeu20MsMzBt.TBNAME,RepaVbjaMeu20MsMzBt.SZKBN));
        selectSql.append(String.format("        ,%s.%s ",RepaVbjaMeu20MsMzBt.TBNAME,RepaVbjaMeu20MsMzBt.SINZATSUBTAICD));
        selectSql.append(String.format("        ,%s.%s ",RepaVbjaMeu20MsMzBt.TBNAME,RepaVbjaMeu20MsMzBt.KBANCD));

        return selectSql.toString();
    }

    /**
     * MEU07SIKKRSPRDVO取得のSQL文を返します
     *
     * @return String SQL文
     */
    private String getSelectSQLMEU07SIKKRSPRDVO()
    {
        StringBuffer sqlSelect = new StringBuffer();
        String whereSqlStr = "";

        sqlSelect.append(String.format("SELECT %s.%s AS %s ","D","SIKCD","SIKCD"));
        sqlSelect.append(String.format("      ,%s.%s AS %s ","D","ENDYMD","ENDYMD"));
        sqlSelect.append(String.format("      ,%s.%s AS %s ","D","STARTYMD","STARTYMD"));
        sqlSelect.append(String.format("      ,%s.%s AS %s ","D","HYOJIKJ","HYOJIKJ"));
        sqlSelect.append(String.format("      ,%s.%s AS %s ","D","KYKHYOJIKJ","KYKHYOJIKJ"));
        sqlSelect.append(String.format("      ,%s.%s AS %s ","D","SITUHYOJIKJ","SITUHYOJIKJ"));
        sqlSelect.append(String.format("      ,%s.%s AS %s ","D","BUHYOJIKJ","BUHYOJIKJ"));
        sqlSelect.append(String.format("      ,%s.%s AS %s ","D","KAHYOJIKJ","KAHYOJIKJ"));
        sqlSelect.append(String.format("FROM "));
        sqlSelect.append(String.format("     ( "));
        sqlSelect.append(String.format("        SELECT %s.%s AS %s ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.SIKCD,"SIKCD"));
        sqlSelect.append(String.format("              ,%s.%s AS %s ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.ENDYMD,"ENDYMD"));
        sqlSelect.append(String.format("              ,%s.%s AS %s ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.STARTYMD,"STARTYMD"));
        sqlSelect.append(String.format("              ,%s.%s AS %s ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.HYOJIKJ,"HYOJIKJ"));
        sqlSelect.append(String.format("              ,%s.%s AS %s ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.KYKHYOJIKJ,"KYKHYOJIKJ"));
        sqlSelect.append(String.format("              ,%s.%s AS %s ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.SITUHYOJIKJ,"SITUHYOJIKJ"));
        sqlSelect.append(String.format("              ,%s.%s AS %s ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.BUHYOJIKJ,"BUHYOJIKJ"));
        sqlSelect.append(String.format("              ,%s.%s AS %s ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.KAHYOJIKJ,"KAHYOJIKJ"));
        sqlSelect.append(String.format("        FROM %s ",RepaVbjaMeu07SikKrSprd.TBNAME));
        sqlSelect.append(String.format("        WHERE %s.%s <= '%s' ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.STARTYMD,_condMEU07SIKKRSPRD.getHIDUKE()));
        sqlSelect.append(String.format("        AND   %s.%s >= '%s' ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.ENDYMD,_condMEU07SIKKRSPRD.getHIDUKE()));
        sqlSelect.append(String.format("     ) %s ","D"));

        if ((_condMEU07SIKKRSPRD != null) && (_condMEU07SIKKRSPRD.getSIKCDList() != null))
        {
            for (int i = 0 ; i < _condMEU07SIKKRSPRD.getSIKCDList().size() ; i++)
            {
                StringBuffer whereSql = new StringBuffer();

                whereSql.append(String.format("%s.%s = '%s' ","D","SIKCD",_condMEU07SIKKRSPRD.getSIKCDList().get(i)));
                String workWhereSql = whereSql.toString();
                if (workWhereSql.length() > 0)
                {
                    if (whereSqlStr.length() == 0)
                    {
                        whereSqlStr += " WHERE ( ";
                    }
                    else
                    {
                        whereSqlStr += " OR ( ";
                    }

                    whereSqlStr += workWhereSql;

                    whereSqlStr += ") ";

                }
            }
        }

        return sqlSelect.toString() + whereSqlStr;
    }

    /**
     * MEU07SIKKRSPRDVO取得のSQL文を返します（含む検索）
     *
     * @return String SQL文
     */
    private String getSelectSQLLikeMEU07SIKKRSPRDVO()
    {
        StringBuffer selectSql = new StringBuffer();
        StringBuffer whereSql = new StringBuffer();
        StringBuffer orderSql = new StringBuffer();

        selectSql.append(String.format("SELECT %s.%s AS %s ","D","SIKCD","SIKCD"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D","ENDYMD","ENDYMD"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D","STARTYMD","STARTYMD"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D","HYOJIKJ","HYOJIKJ"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D","KYKHYOJIKJ","KYKHYOJIKJ"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D","SITUHYOJIKJ","SITUHYOJIKJ"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D","BUHYOJIKJ","BUHYOJIKJ"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D","KAHYOJIKJ","KAHYOJIKJ"));
        selectSql.append(String.format("FROM "));
        selectSql.append(String.format("     ( "));
        selectSql.append(String.format("        SELECT %s.%s AS %s ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.SIKCD,"SIKCD"));
        selectSql.append(String.format("              ,%s.%s AS %s ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.ENDYMD,"ENDYMD"));
        selectSql.append(String.format("              ,%s.%s AS %s ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.STARTYMD,"STARTYMD"));
        selectSql.append(String.format("              ,%s.%s AS %s ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.HYOJIKN,"HYOJIKN"));
        selectSql.append(String.format("              ,%s.%s AS %s ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.KYKHYOJIKN,"KYKHYOJIKN"));
        selectSql.append(String.format("              ,%s.%s AS %s ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.SITUHYOJIKN,"SITUHYOJIKN"));
        selectSql.append(String.format("              ,%s.%s AS %s ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.BUHYOJIKN,"BUHYOJIKN"));
        selectSql.append(String.format("              ,%s.%s AS %s ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.KAHYOJIKN,"KAHYOJIKN"));
        selectSql.append(String.format("              ,%s.%s AS %s ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.HYOJIKJ,"HYOJIKJ"));
        selectSql.append(String.format("              ,%s.%s AS %s ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.KYKHYOJIKJ,"KYKHYOJIKJ"));
        selectSql.append(String.format("              ,%s.%s AS %s ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.SITUHYOJIKJ,"SITUHYOJIKJ"));
        selectSql.append(String.format("              ,%s.%s AS %s ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.BUHYOJIKJ,"BUHYOJIKJ"));
        selectSql.append(String.format("              ,%s.%s AS %s ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.KAHYOJIKJ,"KAHYOJIKJ"));
        selectSql.append(String.format("        FROM %s ",RepaVbjaMeu07SikKrSprd.TBNAME));
        selectSql.append(String.format("        WHERE %s.%s <= '%s' ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.STARTYMD,_likeCondMEU07SIKKRSPRD.getHIDUKE()));
        selectSql.append(String.format("        AND   %s.%s >= '%s' ",RepaVbjaMeu07SikKrSprd.TBNAME,RepaVbjaMeu07SikKrSprd.ENDYMD,_likeCondMEU07SIKKRSPRD.getHIDUKE()));
        selectSql.append(String.format("     ) %s ","D"));

        if ((_likeCondMEU07SIKKRSPRD.getSIKCD() != null) && (!_likeCondMEU07SIKKRSPRD.getSIKCD().isEmpty()))
        {
            if (whereSql.length() == 0)
            {
                whereSql.append(String.format("WHERE %s.%s LIKE '%%%s%%' ","D","SIKCD",_likeCondMEU07SIKKRSPRD.getSIKCD()));
            }
            else
            {
                whereSql.append(String.format("AND   %s.%s LIKE '%%%s%%' ","D","SIKCD",_likeCondMEU07SIKKRSPRD.getSIKCD()));
            }
        }

        if ((_likeCondMEU07SIKKRSPRD.getHYOJI() != null) && (!_likeCondMEU07SIKKRSPRD.getHYOJI().isEmpty()))
        {
            if (whereSql.length() == 0)
            {
                whereSql.append(String.format("WHERE (%s.%s LIKE '%%%s%%' OR (%s.%s || %s.%s || %s.%s || %s.%s) LIKE '%%%s%%' OR %s.%s LIKE '%%%s%%' OR (%s.%s || %s.%s || %s.%s || %s.%s) LIKE '%%%s%%') ",
                                              "D","HYOJIKJ",_likeCondMEU07SIKKRSPRD.getHYOJI(),
                                              "D","KYKHYOJIKJ","D","SITUHYOJIKJ","D","BUHYOJIKJ","D","KAHYOJIKJ",_likeCondMEU07SIKKRSPRD.getHYOJI(),
                                              "D","HYOJIKN",_likeCondMEU07SIKKRSPRD.getHYOJI(),
                                              "D","KYKHYOJIKN","D","SITUHYOJIKN","D","BUHYOJIKN","D","KAHYOJIKN",_likeCondMEU07SIKKRSPRD.getHYOJI()));
            }
            else
            {
                whereSql.append(String.format("AND   (%s.%s LIKE '%%%s%%' OR (%s.%s || %s.%s || %s.%s || %s.%s) LIKE '%%%s%%' OR %s.%s LIKE '%%%s%%' OR (%s.%s || %s.%s || %s.%s || %s.%s) LIKE '%%%s%%')  ",
                                              "D","HYOJIKJ",_likeCondMEU07SIKKRSPRD.getHYOJI(),
                                              "D","KYKHYOJIKJ","D","SITUHYOJIKJ","D","BUHYOJIKJ","D","KAHYOJIKJ",_likeCondMEU07SIKKRSPRD.getHYOJI(),
                                              "D","HYOJIKN",_likeCondMEU07SIKKRSPRD.getHYOJI(),
                                              "D","KYKHYOJIKN","D","SITUHYOJIKN","D","BUHYOJIKN","D","KAHYOJIKN",_likeCondMEU07SIKKRSPRD.getHYOJI()));
            }
        }

        orderSql.append(String.format("ORDER BY %s.%s ","D","SIKCD"));

        return selectSql.toString() + whereSql.toString() + orderSql.toString();

    }

    /**
     * テーブル列名を取得する（Vbj01AccUser）
     *
     * @return String[] テーブル列名（Vbj01AccUser）
     */
    public String[] getTableColumnNamesVbj01AccUser()
    {
        return new String[]
        {
                 Vbj01AccUser.ESQID
                ,Vbj01AccUser.POSTSTATE
                ,Vbj01AccUser.CN
                ,Vbj01AccUser.SIKOGNZUNTCD
                ,Vbj01AccUser.MAIL
                ,Vbj01AccUser.HBSIKOGNZUNTCD
                ,Vbj01AccUser.HBOU
                ,Vbj01AccUser.KKSIKOGNZUNTCD
                ,Vbj01AccUser.KKOU
                ,Vbj01AccUser.HTSIKOGNZUNTCD
                ,Vbj01AccUser.HTOU
                ,Vbj01AccUser.BUSIKOGNZUNTCD
                ,Vbj01AccUser.BUOU
                ,Vbj01AccUser.KASIKOGNZUNTCD
                ,Vbj01AccUser.KAOU
        };
    }

    /**
     * AbstractModelの値の設定有無からSQLのWHERE句を生成する
     * @param vo
     * @return
     */
    private String vbj01AccUserWhereByCond(AbstractModel vo)
    {
        StringBuffer sql = new StringBuffer();

        for (int i = 0; i < getTableColumnNamesVbj01AccUser().length; i++)
        {
            Object value = vo.get(getTableColumnNamesVbj01AccUser()[i]);
            if (value != null)
            {
                if (sql.length() == 0)
                {
                    sql.append(" ");
                }
                else
                {
                    sql.append(" AND ");
                }
                sql.append(getTableColumnNamesVbj01AccUser()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
            }
        }

        return sql.toString();
    }

    /**
     * Vbj01AccUserVO取得のSQL文を返します
     *
     * @return String SQL文
     */
    private String getSelectSQLVbj01AccUserVO()
    {
        StringBuffer sqlSelect = new StringBuffer();
        String whereSqlStr = "";

        sqlSelect.append(String.format("SELECT %s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.ESQID,"ESQID"));
        sqlSelect.append(String.format("      ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.POSTSTATE,"POSTSTATE"));
        sqlSelect.append(String.format("      ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.CN,"CN"));
        sqlSelect.append(String.format("      ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.SIKOGNZUNTCD,"SIKOGNZUNTCD"));
        sqlSelect.append(String.format("      ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.MAIL,"MAIL"));
        sqlSelect.append(String.format("      ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.HBSIKOGNZUNTCD,"HBSIKOGNZUNTCD"));
        sqlSelect.append(String.format("      ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.HBOU,"HBOU"));
        sqlSelect.append(String.format("      ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.KKSIKOGNZUNTCD,"KKSIKOGNZUNTCD"));
        sqlSelect.append(String.format("      ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.KKOU,"KKOU"));
        sqlSelect.append(String.format("      ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.HTSIKOGNZUNTCD,"HTSIKOGNZUNTCD"));
        sqlSelect.append(String.format("      ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.HTOU,"HTOU"));
        sqlSelect.append(String.format("      ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.BUSIKOGNZUNTCD,"BUSIKOGNZUNTCD"));
        sqlSelect.append(String.format("      ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.BUOU,"BUOU"));
        sqlSelect.append(String.format("      ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.KASIKOGNZUNTCD,"KASIKOGNZUNTCD"));
        sqlSelect.append(String.format("      ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.KAOU,"KAOU"));
        sqlSelect.append(" FROM ");
        sqlSelect.append(Vbj01AccUser.TBNAME);

        if ((_condAccUser != null) && (_condAccUser.getConditionListAccUser() != null))
        {
            for (int i = 0 ; i < _condAccUser.getConditionListAccUser().size() ; i++)
            {
                Vbj01AccUserVO vo = new Vbj01AccUserVO();
                vo.setESQID(_condAccUser.getConditionListAccUser().get(i).getEsqid());
                vo.setPOSTSTATE(_condAccUser.getConditionListAccUser().get(i).getPoststate());
                vo.setCN(_condAccUser.getConditionListAccUser().get(i).getCn());
                vo.setSIKOGNZUNTCD(_condAccUser.getConditionListAccUser().get(i).getSikognzuntcd());
                vo.setMAIL(_condAccUser.getConditionListAccUser().get(i).getMail());
                vo.setHBSIKOGNZUNTCD(_condAccUser.getConditionListAccUser().get(i).getHbsikognzuntcd());
                vo.setHBOU(_condAccUser.getConditionListAccUser().get(i).getHbou());
                vo.setKKSIKOGNZUNTCD(_condAccUser.getConditionListAccUser().get(i).getKksikognzuntcd());
                vo.setKKOU(_condAccUser.getConditionListAccUser().get(i).getKkou());
                vo.setHTSIKOGNZUNTCD(_condAccUser.getConditionListAccUser().get(i).getHtsikognzuntcd());
                vo.setHTOU(_condAccUser.getConditionListAccUser().get(i).getHtou());
                vo.setBUSIKOGNZUNTCD(_condAccUser.getConditionListAccUser().get(i).getBusikognzuntcd());
                vo.setBUOU(_condAccUser.getConditionListAccUser().get(i).getBuou());
                vo.setKASIKOGNZUNTCD(_condAccUser.getConditionListAccUser().get(i).getKasikognzuntcd());
                vo.setKAOU(_condAccUser.getConditionListAccUser().get(i).getKaou());

                String workWhereSql = vbj01AccUserWhereByCond(vo);
                if (workWhereSql.length() > 0)
                {
                    if (whereSqlStr.length() == 0)
                    {
                        whereSqlStr += " WHERE ( ";
                    }
                    else
                    {
                        whereSqlStr += " OR ( ";
                    }

                    whereSqlStr += workWhereSql;

                    whereSqlStr += ") ";

                }
            }
        }

        return sqlSelect.toString() + whereSqlStr;
    }

    /**
     * Vbj01AccUserVO取得のSQL文を返します（含む検索）
     *
     * @return String SQL文
     */
    private String getSelectSQLLikeVbj01AccUserVO()
    {
        StringBuffer selectSql = new StringBuffer();
        StringBuffer whereSql = new StringBuffer();

        selectSql.append(String.format("SELECT %s.%s AS %s ","D","ESQID","ESQID"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D","POSTSTATE","POSTSTATE"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D","CN","CN"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D","SIKOGNZUNTCD","SIKOGNZUNTCD"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D","MAIL","MAIL"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D","HBSIKOGNZUNTCD","HBSIKOGNZUNTCD"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D","HBOU","HBOU"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D","KKSIKOGNZUNTCD","KKSIKOGNZUNTCD"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D","KKOU","KKOU"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D","HTSIKOGNZUNTCD","HTSIKOGNZUNTCD"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D","HTOU","HTOU"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D","BUSIKOGNZUNTCD","BUSIKOGNZUNTCD"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D","BUOU","BUOU"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D","KASIKOGNZUNTCD","KASIKOGNZUNTCD"));
        selectSql.append(String.format("      ,%s.%s AS %s ","D","KAOU","KAOU"));
        selectSql.append(String.format("FROM "));
        selectSql.append(String.format("     ( "));
        selectSql.append(String.format("        SELECT %s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.ESQID,"ESQID"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.POSTSTATE,"POSTSTATE"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.CN,"CN"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.SIKOGNZUNTCD,"SIKOGNZUNTCD"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.MAIL,"MAIL"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.HBSIKOGNZUNTCD,"HBSIKOGNZUNTCD"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.HBOU,"HBOU"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.KKSIKOGNZUNTCD,"KKSIKOGNZUNTCD"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.KKOU,"KKOU"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.HTSIKOGNZUNTCD,"HTSIKOGNZUNTCD"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.HTOU,"HTOU"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.BUSIKOGNZUNTCD,"BUSIKOGNZUNTCD"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.BUOU,"BUOU"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.KASIKOGNZUNTCD,"KASIKOGNZUNTCD"));
        selectSql.append(String.format("              ,%s.%s AS %s ",Vbj01AccUser.TBNAME,Vbj01AccUser.KAOU,"KAOU"));
        selectSql.append(String.format("        FROM %s ",Vbj01AccUser.TBNAME));
        selectSql.append(String.format("     ) %s ","D"));

        if ((_likeCondAccUser.getHAMID() != null) && (!_likeCondAccUser.getHAMID().isEmpty()))
        {
            if (whereSql.length() == 0)
            {
                whereSql.append(String.format("WHERE %s.%s LIKE '%%%s%%' ","D","ESQID",_likeCondAccUser.getHAMID()));
            }
            else
            {
                whereSql.append(String.format("AND   %s.%s LIKE '%%%s%%' ","D","ESQID",_likeCondAccUser.getHAMID()));
            }
        }

        if ((_likeCondAccUser.getCN() != null) && (!_likeCondAccUser.getCN().isEmpty()))
        {
            if (whereSql.length() == 0)
            {
                whereSql.append(String.format("WHERE %s.%s LIKE '%%%s%%' ","D","CN",_likeCondAccUser.getCN()));
            }
            else
            {
                whereSql.append(String.format("AND   %s.%s LIKE '%%%s%%' ","D","CN",_likeCondAccUser.getCN()));
            }
        }

        if ((_likeCondAccUser.getSOSHIKI() != null) && (!_likeCondAccUser.getSOSHIKI().isEmpty()))
        {
            if (whereSql.length() == 0)
            {
                whereSql.append(String.format("WHERE (%s.%s || %s.%s || %s.%s || %s.%s) LIKE '%%%s%%' ","D","KKOU","D","HTOU","D","BUOU","D","KAOU",_likeCondAccUser.getSOSHIKI()));
            }
            else
            {
                whereSql.append(String.format("AND   (%s.%s || %s.%s || %s.%s || %s.%s) LIKE '%%%s%%' ","D","KKOU","D","HTOU","D","BUOU","D","KAOU",_likeCondAccUser.getSOSHIKI()));
            }
        }

        return selectSql.toString() + whereSql.toString();
    }

    /* 2016/02/16 HDX対応 HLC K.Oki ADD Start */
    /**
     * CarUserSozaiSpreadVO取得のSQL文を返します
     *
     * @return String SQL文
     */
    private String getSelectSQLCarUserSozaiSpreadVO()
    {
        StringBuffer selectSql = new StringBuffer();

        selectSql.append("SELECT");
        selectSql.append(" " + Mbj02User.HAMID  + ",");
        selectSql.append(" " + Mbj02User.USERNAME1 + ",");
        selectSql.append(" " + Mbj02User.USERNAME2 + ",");
        selectSql.append(" " + Mbj52SzTntUser.DCARCD + ",");
        selectSql.append(" " + Mbj52SzTntUser.USERSEQ + ",");
        selectSql.append(" " + Mbj52SzTntUser.SORTNO);

        selectSql.append(" FROM");
        selectSql.append(" " + Mbj02User.TBNAME);
        selectSql.append(" FULL OUTER JOIN");
        selectSql.append(" " + Mbj52SzTntUser.TBNAME + " ON");
        selectSql.append(" TRIM(" + Mbj02User.HAMID + ") = " + Mbj52SzTntUser.USERID);

        selectSql.append(" ORDER BY");
        selectSql.append(" " + Mbj02User.HAMID);

        return selectSql.toString();
    }

    /**
     * HCHMSecGrpUserVO取得のSQL文を返します
     *
     * @return String SQL文
     */
    private String getSelectSQLHCHMSecGrpUserSpreadVO()
    {
        StringBuffer selectSql = new StringBuffer();

        selectSql.append("SELECT");
        selectSql.append(" TRANSEC." + T_TransactionSecurity.USERID + ",");
        selectSql.append(" TRANSEC." + T_TransactionSecurity.TRANSACTIONNO + ",");
        selectSql.append(" USERINFO." + T_UserInfo.USERNAME + ",");
        selectSql.append(" SECGRP." + T_SecurityGroup.SECURITYGROUPCODE + ",");
        selectSql.append(" SECGRP." + T_SecurityGroup.SECURITYGROUPNAME );

        selectSql.append(" FROM");
        selectSql.append(" " + T_TransactionSecurity.TBNAME + " TRANSEC ,");
        selectSql.append(" " + T_UserInfo.TBNAME + " USERINFO ,");
        selectSql.append(" " + T_SecurityGroup.TBNAME + " SECGRP");

        selectSql.append(" WHERE");
        selectSql.append(" TRANSEC." + T_TransactionSecurity.DELETEFLG + " = '" + HAMConstants.ZERO + "' AND ");
        selectSql.append(" TRANSEC." + T_TransactionSecurity.SYSTEMID + " = '" + HAMConstants.SYSTEMID_HDX + "' AND ");
        selectSql.append(" TRANSEC." + T_TransactionSecurity.CLIENTSBT + " = '" + HAMConstants.CLIENTSBT_HDX + "' AND ");
        selectSql.append(" TRANSEC." + T_TransactionSecurity.MENUTABCODE + " = '" + HAMConstants.MENUTABCODE_HDX + "' AND ");
        selectSql.append(" TRANSEC." + T_TransactionSecurity.USERID + " = USERINFO." + T_UserInfo.USERID + " AND ");
        selectSql.append(" USERINFO." + T_UserInfo.DELETEFLG + " = '" + HAMConstants.ZERO + "' AND ");
        selectSql.append(" USERINFO." + T_UserInfo.SYSTEMID + " = '" + HAMConstants.SYSTEMID_HDX + "' AND ");
        selectSql.append(" USERINFO." + T_UserInfo.CLIENTSBT + " = '" + HAMConstants.CLIENTSBT_HDX + "' AND ");
        selectSql.append(" USERINFO." + T_UserInfo.SECURITYGROUPCODE + " = SECGRP." + T_SecurityGroup.SECURITYGROUPCODE + " AND ");
        selectSql.append(" SECGRP." + T_SecurityGroup.DELETEFLG + " = '" + HAMConstants.ZERO + "' AND ");
        selectSql.append(" SECGRP." + T_SecurityGroup.SYSTEMID + " = '" + HAMConstants.SYSTEMID_HDX + "' AND ");
        selectSql.append(" SECGRP." + T_SecurityGroup.CLIENTSBT + " = '" + HAMConstants.CLIENTSBT_HDX + "' ");

        selectSql.append(" ORDER BY");
        selectSql.append(" SECGRP." + T_SecurityGroup.SECURITYGROUPCODE + ",");
        selectSql.append(" TRANSEC." + T_TransactionSecurity.USERID + ",");
        selectSql.append(" TRANSEC." + T_TransactionSecurity.TRANSACTIONNO);

        return selectSql.toString();
    }
    /* 2016/02/16 HDX対応 HLC K.Oki ADD End */

    /**
     * MasterMaintenanceUserSpreadVOの検索を行います
     *
     * @return VOリスト
     * @param condition 検索条件
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<MasterMaintenanceUserSpreadVO> getUserSpreadVO(MasterMaintenanceUserSpreadCondition condition) throws HAMException
    {
        super.setModel(new MasterMaintenanceUserSpreadVO());

        try
        {
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(),"BJ-E0001");
        }

    }

    /**
     * MasterMaintenanceCarAuthoritySpreadVOの検索を行います
     *
     * @return VOリスト
     * @param condition 検索条件
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<MasterMaintenanceCarAuthoritySpreadVO> getCarAuthoritySpreadVO(MasterMaintenanceAuthoritySpreadCondition condition) throws HAMException
    {
        super.setModel(new MasterMaintenanceCarAuthoritySpreadVO());

        try
        {
            _condCarAuthoritySpread = condition;
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(),"BJ-E0001");
        }

    }

    /**
     * MasterMaintenanceMediaAuthoritySpreadVOの検索を行います
     *
     * @return VOリスト
     * @param condition 検索条件
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<MasterMaintenanceMediaAuthoritySpreadVO> getMediaAuthoritySpreadVO(MasterMaintenanceAuthoritySpreadCondition condition) throws HAMException
    {
        super.setModel(new MasterMaintenanceMediaAuthoritySpreadVO());

        try
        {
            _condMediaAuthoritySpread = condition;
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(),"BJ-E0001");
        }

    }

    /**
     * MasterMaintenanceCarUserSpreadVOの検索を行います
     *
     * @return VOリスト
     * @param condition 検索条件
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<MasterMaintenanceCarUserSpreadVO> getCarUserSpreadVO(MasterMaintenanceCarUserSpreadCondition condition) throws HAMException
    {
        super.setModel(new MasterMaintenanceCarUserSpreadVO());

        try
        {
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(),"BJ-E0001");
        }

    }

    /**
     * MasterMaintenanceHCProductSpreadVOの検索を行います
     *
     * @return VOリスト
     * @param condition 検索条件
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<MasterMaintenanceHCProductSpreadVO> getHCProductSpreadVO(MasterMaintenanceHCProductSpreadCondition condition) throws HAMException
    {
        super.setModel(new MasterMaintenanceHCProductSpreadVO());

        try
        {
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(),"BJ-E0001");
        }

    }

    /**
     * MasterMaintenanceFunctionControlSpreadVOの検索を行います
     *
     * @return VOリスト
     * @param condition 検索条件
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<MasterMaintenanceFunctionControlSpreadVO> getFunctionControlSpreadVO(MasterMaintenanceFunctionControlSpreadCondition condition) throws HAMException
    {
        super.setModel(new MasterMaintenanceFunctionControlSpreadVO());

        try
        {
            _condFunctionControlSpread = condition;
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(),"BJ-E0001");
        }

    }

    /**
     * MasterMaintenanceSecuritySpreadVOの検索を行います
     *
     * @return VOリスト
     * @param condition 検索条件
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<MasterMaintenanceSecuritySpreadVO> getSecuritySpreadVO(MasterMaintenanceSecuritySpreadCondition condition) throws HAMException
    {
        super.setModel(new MasterMaintenanceSecuritySpreadVO());

        try
        {
            _condSecuritySpread = condition;
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(),"BJ-E0001");
        }

    }

    /**
     * MasterMaintenanceMEU20MSMZBTVOの検索を行います
     *
     * @return VOリスト
     * @param condition 検索条件
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<MasterMaintenanceMEU20MSMZBTVO> getMasterMaintenanceMEU20MSMZBTVO(MasterMaintenanceMEU20MSMZBTCondition condition) throws HAMException
    {
        super.setModel(new MasterMaintenanceMEU20MSMZBTVO());

        try
        {
            _condMEU20MSMZBT = condition;
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(),"BJ-E0001");
        }

    }

    /**
     * MEU07SIKKRSPRDの検索を行います
     *
     * @return VOリスト
     * @param condition 検索条件
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<MasterMaintenanceMEU07SIKKRSPRDVO> getMasterMaintenanceMEU07SIKKRSPRDVO(MasterMaintenanceMEU07SIKKRSPRDCondition condition) throws HAMException
    {
        super.setModel(new MasterMaintenanceMEU07SIKKRSPRDVO());

        try
        {
            _condMEU07SIKKRSPRD = condition;
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(),"BJ-E0001");
        }

    }

    /**
     * MEU07SIKKRSPRDの検索を行います（含む検索）
     *
     * @return VOリスト
     * @param condition 検索条件
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<MasterMaintenanceMEU07SIKKRSPRDVO> getMasterMaintenanceMEU07SIKKRSPRDVO(MasterMaintenanceMEU07SIKKRSPRDLikeCondition condition) throws HAMException
    {
        super.setModel(new MasterMaintenanceMEU07SIKKRSPRDVO());

        try
        {
            _likeCondMEU07SIKKRSPRD = condition;
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(),"BJ-E0001");
        }

    }

    /**
     * Vbj01AccUserの検索を行います
     *
     * @return VOリスト
     * @param condition 検索条件
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<Vbj01AccUserVO> getMasterMaintenanceAccUserVO(MasterMaintenanceAccUserCondition condition) throws HAMException
    {
        super.setModel(new Vbj01AccUserVO());

        try
        {
            _condAccUser = condition;
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(),"BJ-E0001");
        }

    }

    /**
     * Vbj01AccUserの検索を行います（含む検索）
     *
     * @return VOリスト
     * @param condition 検索条件
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<Vbj01AccUserVO> getMasterMaintenanceAccUserVO(MasterMaintenanceAccUserLikeCondition condition) throws HAMException
    {
        super.setModel(new Vbj01AccUserVO());

        try
        {
            _likeCondAccUser = condition;
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(),"BJ-E0001");
        }

    }

    /* 2016/02/16 HDX対応 HLC K.Oki ADD Start */
    /**
     * MasterMaintenanceCarUserSozaiSpreadVOの検索を行います
     *
     * @return VOリスト
     * @param condition 検索条件
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<MasterMaintenanceCarUserSozaiSpreadVO> getCarUserSozaiSpreadVO(MasterMaintenanceCarUserSozaiSpreadCondition condition) throws HAMException
    {
        super.setModel(new MasterMaintenanceCarUserSozaiSpreadVO());

        try
        {
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(),"BJ-E0001");
        }

    }

    /**
     * MasterMaintenanceHCHMSecGrpUserSpreadVOの検索を行います
     *
     * @return VOリスト
     * @param condition 検索条件
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<MasterMaintenanceHCHMSecGrpUserSpreadVO> getHCHMSecGrpUserSpreadVO(MasterMaintenanceHCHMSecGrpUserSpreadCondition condition) throws HAMException
    {
        super.setModel(new MasterMaintenanceHCHMSecGrpUserSpreadVO());

        try
        {
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(),"BJ-E0001");
        }

    }
    /* 2016/02/16 HDX対応 HLC K.Oki ADD End */

    /**
     * Modelの生成を行う<br>
     * AbstractRdbDaoのcreateFindedModelInstancesをオーバーライド<br>
     *
     * @param hashList List 検索結果
     * @return List 変換後の検索結果
     */
    @SuppressWarnings("unchecked")
    @Override
    protected List createFindedModelInstances(List hashList)
    {
        List list = null;

        if (getModel() instanceof MasterMaintenanceUserSpreadVO)
        {
            list = new ArrayList<MasterMaintenanceUserSpreadVO>();
            for (int i = 0; i < hashList.size(); i++)
            {
                Map result = (Map) hashList.get(i);
                MasterMaintenanceUserSpreadVO vo = new MasterMaintenanceUserSpreadVO();

                vo.setHAMID((String)result.get("HAMID"));
                vo.setUSERNAME1((String)result.get("USERNAME1"));
                vo.setUSERNAME2((String)result.get("USERNAME2"));
                vo.setLOGINHAMID((String)result.get("LOGINHAMID"));
                vo.setUSERTYPE((String)result.get("USERTYPE"));
                vo.setUPDDATE(DateUtil.toDateForNull(result.get("UPDDATE")));
                vo.setUPDNM((String)result.get("UPDNM"));
                vo.setUPDAPL((String)result.get("UPDAPL"));
                vo.setUPDID((String)result.get("UPDID"));

                list.add(vo);
            }
        }
        else if (getModel() instanceof MasterMaintenanceCarAuthoritySpreadVO)
        {
            list = new ArrayList<MasterMaintenanceCarAuthoritySpreadVO>();
            for (int i = 0; i < hashList.size(); i++)
            {
                Map result = (Map) hashList.get(i);
                MasterMaintenanceCarAuthoritySpreadVO vo = new MasterMaintenanceCarAuthoritySpreadVO();

                vo.setSECTYPE((String)result.get("SECTYPE"));
                vo.setHAMID((String)result.get("HAMID"));
                vo.setDCARCD((String)result.get("DCARCD"));
                vo.setCARNM((String)result.get("CARNM"));
                vo.setAUTHORITY((String)result.get("AUTHORITY"));
                vo.setUPDDATE(DateUtil.toDateForNull(result.get("UPDDATE")));
                vo.setUPDNM((String)result.get("UPDNM"));
                vo.setUPDAPL((String)result.get("UPDAPL"));
                vo.setUPDID((String)result.get("UPDID"));

                list.add(vo);
            }
        }
        else if (getModel() instanceof MasterMaintenanceMediaAuthoritySpreadVO)
        {
            list = new ArrayList<MasterMaintenanceMediaAuthoritySpreadVO>();
            for (int i = 0; i < hashList.size(); i++)
            {
                Map result = (Map) hashList.get(i);
                MasterMaintenanceMediaAuthoritySpreadVO vo = new MasterMaintenanceMediaAuthoritySpreadVO();

                vo.setHAMID((String)result.get("HAMID"));
                vo.setMEDIACD((String)result.get("MEDIACD"));
                vo.setMEDIANM((String)result.get("MEDIANM"));
                vo.setAUTHORITY((String)result.get("AUTHORITY"));
                vo.setUPDDATE(DateUtil.toDateForNull(result.get("UPDDATE")));
                vo.setUPDNM((String)result.get("UPDNM"));
                vo.setUPDAPL((String)result.get("UPDAPL"));
                vo.setUPDID((String)result.get("UPDID"));

                list.add(vo);
            }
        }
        else if (getModel() instanceof MasterMaintenanceCarUserSpreadVO)
        {
            list = new ArrayList<MasterMaintenanceCarUserSpreadVO>();
            for (int i = 0; i < hashList.size(); i++)
            {
                Map result = (Map) hashList.get(i);
                MasterMaintenanceCarUserSpreadVO vo = new MasterMaintenanceCarUserSpreadVO();

                vo.setDCARCD((String)result.get("DCARCD"));
                vo.setCARNM((String)result.get("CARNM"));
                vo.setSORTNO((BigDecimal)result.get("SORTNO"));
                vo.setMEDIATANTO((String)result.get("MEDIATANTO"));
                vo.setCRTANTO((String)result.get("CRTANTO"));
                vo.setUPDDATE(DateUtil.toDateForNull(result.get("UPDDATE")));
                vo.setUPDNM((String)result.get("UPDNM"));
                vo.setUPDAPL((String)result.get("UPDAPL"));
                vo.setUPDID((String)result.get("UPDID"));

                list.add(vo);
            }
        }
        else if (getModel() instanceof MasterMaintenanceHCProductSpreadVO)
        {
            list = new ArrayList<MasterMaintenanceHCProductSpreadVO>();
            for (int i = 0; i < hashList.size(); i++)
            {
                Map result = (Map) hashList.get(i);
                MasterMaintenanceHCProductSpreadVO vo = new MasterMaintenanceHCProductSpreadVO();

                vo.setHCPRODUCTCD((BigDecimal)result.get("HCPRODUCTCD"));
                vo.setUSEBUMONCD((String)result.get("USEBUMONCD"));
                vo.setUSEBUMONNM((String)result.get("USEBUMONNM"));
                vo.setMEDIACLASSCD((String)result.get("MEDIACLASSCD"));
                vo.setMEDIACLASSNM((String)result.get("MEDIACLASSNM"));
                vo.setMEDIACD((String)result.get("MEDIACD"));
                vo.setMEDIANM((String)result.get("MEDIANM"));
                vo.setBUSINESSCLASSCD((String)result.get("BUSINESSCLASSCD"));
                vo.setBUSINESSCLASSNM((String)result.get("BUSINESSCLASSNM"));
                vo.setBUSINESSCD((String)result.get("BUSINESSCD"));
                vo.setBUSINESSNM((String)result.get("BUSINESSNM"));
                vo.setPRODUCTCD((String)result.get("PRODUCTCD"));
                vo.setPRODUCTNM((String)result.get("PRODUCTNM"));
                vo.setWEEKCD((String)result.get("WEEKCD"));
                vo.setWEEK((String)result.get("WEEK"));
                vo.setSIZECD((String)result.get("SIZECD"));
                vo.setSIZE((String)result.get("SIZEDATA"));
                vo.setUNITGROUPCD((String)result.get("UNITGROUPCD"));
                vo.setUNITGROUPNM((String)result.get("UNITGROUPNM"));
                vo.setCALKBN((String)result.get("CALKBN"));
                vo.setCALKBNNAME((String)result.get("CALKBNNAME"));
                vo.setUPDDATE(DateUtil.toDateForNull(result.get("UPDDATE")));
                vo.setUPDNM((String)result.get("UPDNM"));
                vo.setUPDAPL((String)result.get("UPDAPL"));
                vo.setUPDID((String)result.get("UPDID"));

                list.add(vo);
            }
        }
        else if (getModel() instanceof MasterMaintenanceFunctionControlSpreadVO)
        {
            list = new ArrayList<MasterMaintenanceFunctionControlSpreadVO>();
            for (int i = 0; i < hashList.size(); i++)
            {
                Map result = (Map) hashList.get(i);
                MasterMaintenanceFunctionControlSpreadVO vo = new MasterMaintenanceFunctionControlSpreadVO();

                vo.setHAMID((String)result.get("HAMID"));
                vo.setFUNCCD((String)result.get("FUNCCD"));
                vo.setFUNCNM((String)result.get("FUNCNM"));
                vo.setFUNCTYPE((String)result.get("FUNCTYPE"));
                vo.setCONTROL((String)result.get("CONTROL"));
                vo.setDEFAULTCONTROL((String)result.get("DEFAULTCONTROL"));
                vo.setITEMTYPE((String)result.get("ITEMTYPE"));
                vo.setUPDDATE(DateUtil.toDateForNull(result.get("UPDDATE")));
                vo.setUPDNM((String)result.get("UPDNM"));
                vo.setUPDAPL((String)result.get("UPDAPL"));
                vo.setUPDID((String)result.get("UPDID"));

                list.add(vo);
            }
        }
        else if (getModel() instanceof MasterMaintenanceSecuritySpreadVO)
        {
            list = new ArrayList<MasterMaintenanceSecuritySpreadVO>();
            for (int i = 0; i < hashList.size(); i++)
            {
                Map result = (Map) hashList.get(i);
                MasterMaintenanceSecuritySpreadVO vo = new MasterMaintenanceSecuritySpreadVO();

                vo.setHAMID((String)result.get("HAMID"));
                vo.setSECURITYCD((String)result.get("SECURITYCD"));
                vo.setSECURITYTYPE((String)result.get("SECURITYTYPE"));
                vo.setSECURITYNM((String)result.get("SECURITYNM"));
                vo.setUPDATE((String)result.get("UPDATE_"));
                vo.setCHECK((String)result.get("CHECK_"));
                vo.setREFERENCE((String)result.get("REFERENCE"));
                vo.setITEMTYPE((String)result.get("ITEMTYPE"));
                vo.setUPDDATE(DateUtil.toDateForNull(result.get("UPDDATE")));
                vo.setUPDNM((String)result.get("UPDNM"));
                vo.setUPDAPL((String)result.get("UPDAPL"));
                vo.setUPDID((String)result.get("UPDID"));

                list.add(vo);
            }
        }
        else if (getModel() instanceof MasterMaintenanceMEU20MSMZBTVO)
        {
            list = new ArrayList<MasterMaintenanceMEU20MSMZBTVO>();
            for (int i = 0; i < hashList.size(); i++)
            {
                Map result = (Map) hashList.get(i);
                MasterMaintenanceMEU20MSMZBTVO vo = new MasterMaintenanceMEU20MSMZBTVO();

                vo.setSZKBN((String)result.get("SZKBN"));
                vo.setSINZATSUBTAICD((String)result.get("SINZATSUBTAICD"));
                vo.setKBANCD((String)result.get("KBANCD"));
                vo.setSINZATSUBTAINMJ((String)result.get("SINZATSUBTAINMJ"));
                vo.setSINZATSUBTAINMK((String)result.get("SINZATSUBTAINMK"));

                list.add(vo);
            }
        }
        else if (getModel() instanceof MasterMaintenanceMEU07SIKKRSPRDVO)
        {
            list = new ArrayList<MasterMaintenanceMEU07SIKKRSPRDVO>();
            for (int i = 0; i < hashList.size(); i++)
            {
                Map result = (Map) hashList.get(i);
                MasterMaintenanceMEU07SIKKRSPRDVO vo = new MasterMaintenanceMEU07SIKKRSPRDVO();

                vo.setSIKCD((String)result.get("SIKCD"));
                vo.setENDYMD((String)result.get("ENDYMD"));
                vo.setSTARTYMD((String)result.get("STARTYMD"));
                vo.setHYOJIKJ((String)result.get("HYOJIKJ"));
                vo.setKYKHYOJIKJ((String)result.get("KYKHYOJIKJ"));
                vo.setSITUHYOJIKJ((String)result.get("SITUHYOJIKJ"));
                vo.setBUHYOJIKJ((String)result.get("BUHYOJIKJ"));
                vo.setKAHYOJIKJ((String)result.get("KAHYOJIKJ"));

                list.add(vo);
            }
        }
        else if (getModel() instanceof Vbj01AccUserVO)
        {
            list = new ArrayList<Vbj01AccUserVO>();
            for (int i = 0; i < hashList.size(); i++)
            {
                Map result = (Map) hashList.get(i);
                Vbj01AccUserVO vo = new Vbj01AccUserVO();

                vo.setESQID((String)result.get("ESQID"));
                vo.setPOSTSTATE((String)result.get("POSTSTATE"));
                vo.setCN((String)result.get("CN"));
                vo.setSIKOGNZUNTCD((String)result.get("SIKOGNZUNTCD"));
                vo.setMAIL((String)result.get("MAIL"));
                vo.setHBSIKOGNZUNTCD((String)result.get("HBSIKOGNZUNTCD"));
                vo.setHBOU((String)result.get("HBOU"));
                vo.setKKSIKOGNZUNTCD((String)result.get("KKSIKOGNZUNTCD"));
                vo.setKKOU((String)result.get("KKOU"));
                vo.setHTSIKOGNZUNTCD((String)result.get("HTSIKOGNZUNTCD"));
                vo.setHTOU((String)result.get("HTOU"));
                vo.setBUSIKOGNZUNTCD((String)result.get("BUSIKOGNZUNTCD"));
                vo.setBUOU((String)result.get("BUOU"));
                vo.setKASIKOGNZUNTCD((String)result.get("KASIKOGNZUNTCD"));
                vo.setKAOU((String)result.get("KAOU"));

                list.add(vo);
            }
        }
        /* 2016/02/18 HDX対応 HLC K.Oki ADD Start */
        //車種担当(素材)の場合
        else if (getModel() instanceof MasterMaintenanceCarUserSozaiSpreadVO)
        {
            list = new ArrayList<MasterMaintenanceCarUserSozaiSpreadVO>();
            for (int i = 0; i < hashList.size(); i++)
            {
                Map result = (Map) hashList.get(i);
                MasterMaintenanceCarUserSozaiSpreadVO vo = new MasterMaintenanceCarUserSozaiSpreadVO();

                vo.setHAMID(result.get(Mbj02User.HAMID).toString());
                vo.setUSERNAME1(result.get(Mbj02User.USERNAME1).toString());
                vo.setUSERNAME2(result.get(Mbj02User.USERNAME2).toString());
                vo.setDCARCD(result.get(Mbj52SzTntUser.DCARCD).toString());
                vo.setUSERSEQ((BigDecimal)result.get(Mbj52SzTntUser.USERSEQ));
                vo.setSORTNO((BigDecimal)result.get(Mbj52SzTntUser.SORTNO));

                list.add(vo);
            }
        }
        //セキュリグループユーザー(HC／HM)
        else if (getModel() instanceof MasterMaintenanceHCHMSecGrpUserSpreadVO)
        {
            list = new ArrayList<MasterMaintenanceHCHMSecGrpUserSpreadVO>();
            for (int i = 0; i < hashList.size(); i++)
            {
                Map result = (Map) hashList.get(i);
                MasterMaintenanceHCHMSecGrpUserSpreadVO vo = new MasterMaintenanceHCHMSecGrpUserSpreadVO();

                vo.setUSERID(result.get(T_TransactionSecurity.USERID).toString());
                vo.setTRANSACTIONNO(result.get(T_TransactionSecurity.TRANSACTIONNO).toString());
                vo.setUSERNAME(result.get(T_UserInfo.USERNAME).toString());
                vo.setSECURITYGROUPCODE(result.get(T_SecurityGroup.SECURITYGROUPCODE).toString());
                vo.setSECURITYGROUPNAME(result.get(T_SecurityGroup.SECURITYGROUPNAME).toString());

                list.add(vo);
            }
        }
        /* 2016/02/18 HDX対応 HLC K.Oki ADD End */

        return list;
    }

}
