package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj23LogEigyoDaicho;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * �c�ƍ�Ƒ䒠�ύX���ODAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj23LogEigyoDaichoDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private String _DaichoNo = null;
    private enum SqlMode{ALL,MAX};
    private SqlMode _sqlMode = SqlMode.ALL;
    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj23LogEigyoDaichoDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * �v���C�}���L�[���擾����
     *
     * @return String[] �v���C�}���L�[
     */
    public String[] getPrimryKeyNames() {
        return new String[] {
                Tbj23LogEigyoDaicho.MEDIAPLANNO
                ,Tbj23LogEigyoDaicho.DAICHONO
                ,Tbj23LogEigyoDaicho.HISTORYNO
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Tbj23LogEigyoDaicho.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj23LogEigyoDaicho.CRTDATE
                ,Tbj23LogEigyoDaicho.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj23LogEigyoDaicho.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj23LogEigyoDaicho.MEDIAPLANNO
                ,Tbj23LogEigyoDaicho.DAICHONO
                ,Tbj23LogEigyoDaicho.HISTORYNO
                ,Tbj23LogEigyoDaicho.HISTORYKBN
                ,Tbj23LogEigyoDaicho.IMPKEY
                ,Tbj23LogEigyoDaicho.SEIKYUYM
                ,Tbj23LogEigyoDaicho.MEDIACD
                ,Tbj23LogEigyoDaicho.MEDIASCD
                ,Tbj23LogEigyoDaicho.MEDIASNM
                ,Tbj23LogEigyoDaicho.KEIRETSUCD
                ,Tbj23LogEigyoDaicho.DCARCD
                ,Tbj23LogEigyoDaicho.HIYOUNO
                ,Tbj23LogEigyoDaicho.KIKAKUNO
                ,Tbj23LogEigyoDaicho.CAMPAIGN
                ,Tbj23LogEigyoDaicho.NAIYOHIMOKU
                ,Tbj23LogEigyoDaicho.SPACE
                ,Tbj23LogEigyoDaicho.NPDIVISION
                ,Tbj23LogEigyoDaicho.PUBLISHVER
                ,Tbj23LogEigyoDaicho.SYMBOLDIVISION
                ,Tbj23LogEigyoDaicho.POSTEDSURFACE
                ,Tbj23LogEigyoDaicho.UNIT
                ,Tbj23LogEigyoDaicho.CONTRACTDIVISION
                ,Tbj23LogEigyoDaicho.KIKANFROM
                ,Tbj23LogEigyoDaicho.KIKANTO
                ,Tbj23LogEigyoDaicho.GENKAFLG
                ,Tbj23LogEigyoDaicho.GROSS
                ,Tbj23LogEigyoDaicho.DNEBIKIRITSU
                ,Tbj23LogEigyoDaicho.DNEBIKIGAKU
                ,Tbj23LogEigyoDaicho.HMCOST
                ,Tbj23LogEigyoDaicho.APLRIEKIRITSU
                ,Tbj23LogEigyoDaicho.APLRIEKIGAKU
                ,Tbj23LogEigyoDaicho.MEDIAHARAI
                ,Tbj23LogEigyoDaicho.MEDIAMARGINRITSU
                ,Tbj23LogEigyoDaicho.MEDIAMARGINGAKU
                ,Tbj23LogEigyoDaicho.MEDIAGENKA
                ,Tbj23LogEigyoDaicho.TORIRIEKI
                ,Tbj23LogEigyoDaicho.RIEKIHAIBUN
                ,Tbj23LogEigyoDaicho.NAIKINRIEKI
                ,Tbj23LogEigyoDaicho.FURIKAERIEKI
                ,Tbj23LogEigyoDaicho.EIGYOYOIN
                ,Tbj23LogEigyoDaicho.FURIKAERIEKI2
                ,Tbj23LogEigyoDaicho.TVTMEDIATANKA
                ,Tbj23LogEigyoDaicho.TVTHMTANKA
                ,Tbj23LogEigyoDaicho.COLORFEE
                ,Tbj23LogEigyoDaicho.DESIGNATIONFEE
                ,Tbj23LogEigyoDaicho.DOUBLEFEE
                ,Tbj23LogEigyoDaicho.RECLASSIFICATIONFEE
                ,Tbj23LogEigyoDaicho.SPACEFEE
                ,Tbj23LogEigyoDaicho.SPLITRUNFEE
                ,Tbj23LogEigyoDaicho.REQUESTDESTINATION
                ,Tbj23LogEigyoDaicho.BRDDATE
                ,Tbj23LogEigyoDaicho.BIKO
                ,Tbj23LogEigyoDaicho.SEIKYUFLG
                ,Tbj23LogEigyoDaicho.CPDATE
                ,Tbj23LogEigyoDaicho.BRDSEC
                ,Tbj23LogEigyoDaicho.FILEOUTFLG
                ,Tbj23LogEigyoDaicho.APPEARANCEDATE
                ,Tbj23LogEigyoDaicho.SORTNO
                ,Tbj23LogEigyoDaicho.CRTDATE
                ,Tbj23LogEigyoDaicho.CRTNM
                ,Tbj23LogEigyoDaicho.CRTAPL
                ,Tbj23LogEigyoDaicho.CRTID
                ,Tbj23LogEigyoDaicho.UPDDATE
                ,Tbj23LogEigyoDaicho.UPDNM
                ,Tbj23LogEigyoDaicho.UPDAPL
                ,Tbj23LogEigyoDaicho.UPDID
        };
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {
        String sql ="";
        if (_sqlMode.equals(SqlMode.MAX)) {
            sql =getMaxHistoryNoSQLByCondition();
        } else if (_sqlMode.equals(SqlMode.ALL)) {
            sql = getLogEigyoDaicho();
        }
        return sql;
    }

    /** ����NOMAX�l�擾SQL */
    private String getMaxHistoryNoSQLByCondition() {

         StringBuffer sql = new StringBuffer();

         sql.append("SELECT ");
         sql.append(" NVL(MAX(" + Tbj23LogEigyoDaicho.HISTORYNO + "), 0) AS " + Tbj23LogEigyoDaicho.HISTORYNO + " " );
         sql.append(" FROM ");
         sql.append(" " + getTableName() + " ");
         sql.append(" WHERE ");
         sql.append(" " + Tbj23LogEigyoDaicho.DAICHONO + " = '" + _DaichoNo + "' ");

         return sql.toString();
    }

    /** �Ώۂ̉c�Ƒ䒠�����擾SQL */
    private String getLogEigyoDaicho()
    {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        //�S���ڂ��擾
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj23LogEigyoDaicho.DAICHONO + " = " + _DaichoNo + " ");
        sql.append(" ORDER BY ");
        sql.append(" " + Tbj23LogEigyoDaicho.HISTORYNO + " ");

        return sql.toString();
    }

    /**
     * �c�ƍ�Ƒ䒠�����擾
     * @param �}�̊Ǘ�No
     * @return �擾�f�[�^
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj23LogEigyoDaichoVO> FindEigyoDaichoHistory(String daichoNo) throws HAMException {

        super.setModel(new Tbj23LogEigyoDaichoVO());

        try {
            _sqlMode = SqlMode.ALL;
            _DaichoNo = daichoNo;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * ����NOMAX�l�擾
     * @param �}�̊Ǘ�No
     * @return �擾�f�[�^
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj23LogEigyoDaichoVO> FindEigyoDaichoMaxHistoryNo(String daichoNo) throws HAMException {

        super.setModel(new Tbj23LogEigyoDaichoVO());

        try {
            _sqlMode = SqlMode.MAX;
            _DaichoNo = daichoNo;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
