package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.ConcurrentUpdateException;
import jp.co.isid.nj.integ.UpdateFailureException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �c�ƍ�Ƒ䒠DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Tbj02EigyoDaichoDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private Tbj02EigyoDaichoCondition _condition = null;
    private String _mediaPlanNo;
    private String _seikyuYM;
    private String _daichoNo;
    private enum SqlMode{ FIND, MAX, BYMEDIAPLANNO, LAST, BYDAICHONO, SUM, SORTNO};
    private SqlMode _sqlMode = SqlMode.FIND;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj02EigyoDaichoDAO() {
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
                Tbj02EigyoDaicho.MEDIAPLANNO
                ,Tbj02EigyoDaicho.DAICHONO
        };
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return Tbj02EigyoDaicho.UPDDATE;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj02EigyoDaicho.CRTDATE
                ,Tbj02EigyoDaicho.UPDDATE
        };
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj02EigyoDaicho.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj02EigyoDaicho.MEDIAPLANNO
                ,Tbj02EigyoDaicho.DAICHONO
                ,Tbj02EigyoDaicho.IMPKEY
                ,Tbj02EigyoDaicho.SEIKYUYM
                ,Tbj02EigyoDaicho.MEDIACD
                ,Tbj02EigyoDaicho.MEDIASCD
                ,Tbj02EigyoDaicho.MEDIASNM
                ,Tbj02EigyoDaicho.KEIRETSUCD
                ,Tbj02EigyoDaicho.DCARCD
                ,Tbj02EigyoDaicho.HIYOUNO
                ,Tbj02EigyoDaicho.KIKAKUNO
                ,Tbj02EigyoDaicho.CAMPAIGN
                ,Tbj02EigyoDaicho.NAIYOHIMOKU
                ,Tbj02EigyoDaicho.SPACE
                ,Tbj02EigyoDaicho.NPDIVISION
                ,Tbj02EigyoDaicho.PUBLISHVER
                ,Tbj02EigyoDaicho.SYMBOLDIVISION
                ,Tbj02EigyoDaicho.POSTEDSURFACE
                ,Tbj02EigyoDaicho.UNIT
                ,Tbj02EigyoDaicho.CONTRACTDIVISION
                ,Tbj02EigyoDaicho.KIKANFROM
                ,Tbj02EigyoDaicho.KIKANTO
                ,Tbj02EigyoDaicho.GENKAFLG
                ,Tbj02EigyoDaicho.GROSS
                ,Tbj02EigyoDaicho.DNEBIKIRITSU
                ,Tbj02EigyoDaicho.DNEBIKIGAKU
                ,Tbj02EigyoDaicho.HMCOST
                ,Tbj02EigyoDaicho.APLRIEKIRITSU
                ,Tbj02EigyoDaicho.APLRIEKIGAKU
                ,Tbj02EigyoDaicho.MEDIAHARAI
                ,Tbj02EigyoDaicho.MEDIAMARGINRITSU
                ,Tbj02EigyoDaicho.MEDIAMARGINGAKU
                ,Tbj02EigyoDaicho.MEDIAGENKA
                ,Tbj02EigyoDaicho.TORIRIEKI
                ,Tbj02EigyoDaicho.RIEKIHAIBUN
                ,Tbj02EigyoDaicho.NAIKINRIEKI
                ,Tbj02EigyoDaicho.FURIKAERIEKI
                ,Tbj02EigyoDaicho.EIGYOYOIN
                ,Tbj02EigyoDaicho.FURIKAERIEKI2
                ,Tbj02EigyoDaicho.TVTMEDIATANKA
                ,Tbj02EigyoDaicho.TVTHMTANKA
                ,Tbj02EigyoDaicho.COLORFEE
                ,Tbj02EigyoDaicho.DESIGNATIONFEE
                ,Tbj02EigyoDaicho.DOUBLEFEE
                ,Tbj02EigyoDaicho.RECLASSIFICATIONFEE
                ,Tbj02EigyoDaicho.SPACEFEE
                ,Tbj02EigyoDaicho.SPLITRUNFEE
                ,Tbj02EigyoDaicho.REQUESTDESTINATION
                ,Tbj02EigyoDaicho.BRDDATE
                ,Tbj02EigyoDaicho.BIKO
                ,Tbj02EigyoDaicho.SEIKYUFLG
                ,Tbj02EigyoDaicho.CPDATE
                ,Tbj02EigyoDaicho.BRDSEC
                ,Tbj02EigyoDaicho.FILEOUTFLG
                ,Tbj02EigyoDaicho.APPEARANCEDATE
                ,Tbj02EigyoDaicho.SORTNO
                ,Tbj02EigyoDaicho.CRTDATE
                ,Tbj02EigyoDaicho.CRTNM
                ,Tbj02EigyoDaicho.CRTAPL
                ,Tbj02EigyoDaicho.CRTID
                ,Tbj02EigyoDaicho.UPDDATE
                ,Tbj02EigyoDaicho.UPDNM
                ,Tbj02EigyoDaicho.UPDAPL
                ,Tbj02EigyoDaicho.UPDID
        };
    }

    /**
     * AbstractModel�̒l�̐ݒ�L������SQL��WHERE��𐶐�����
     * @param vo
     * @return
     */
    private String generateWhereByCond(AbstractModel vo) {
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

        String sql ="";

        if (_sqlMode.equals(SqlMode.MAX)) {
            sql =getMaxDaichoNoSQLByCondition();
        } else if (_sqlMode.equals(SqlMode.BYMEDIAPLANNO)) {
            sql = getEigyoDaichoByMediaPlanNo();
        } else if (_sqlMode.equals(SqlMode.LAST)) {
            sql = getLastUpdateDaicho();
        } else if (_sqlMode.equals(SqlMode.BYDAICHONO)) {
            sql = getEigyoDaichoByDaichoNo();
        } else if (_sqlMode.equals(SqlMode.SUM)) {
            sql = getEigyoDaichoFeeSUM();
        } else if (_sqlMode.equals(SqlMode.SORTNO)) {
            sql = getMaxSortNo();
        } else {
            sql = getSelectSQLTbj02EigyoDaichoVO();
        }

        return sql;
    }

    /**
     * SELECT SQL(Tbj02EigyoDaichoVO)
     */
    private String getSelectSQLTbj02EigyoDaichoVO() {

        StringBuffer selectSql = new StringBuffer();
        String whereSqlStr = "";
        StringBuffer orderSql = new StringBuffer();

        //*******************************************
        //load()�Afind()�Ŏg�p�����SELECT + FROM���SQL
        //*******************************************
        selectSql.append(" SELECT");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            selectSql.append((i != 0 ? " ," : " "));
            selectSql.append(getTableColumnNames()[i] + " ");
        }

        selectSql.append(" FROM");
        selectSql.append(" " + getTableName());

        if (_condition != null) {

            Tbj02EigyoDaichoVO vo = new Tbj02EigyoDaichoVO();

            vo.setMEDIAPLANNO(_condition.getMediaplanno());
            vo.setDAICHONO(_condition.getDaichono());
            vo.setIMPKEY(_condition.getImpkey());
            vo.setSEIKYUYM(_condition.getSeikyuym());
            vo.setMEDIACD(_condition.getMediacd());
            vo.setMEDIASCD(_condition.getMediascd());
            vo.setMEDIASNM(_condition.getMediasnm());
            vo.setKEIRETSUCD(_condition.getKeiretsucd());
            vo.setDCARCD(_condition.getDcarcd());
            vo.setHIYOUNO(_condition.getHiyouno());
            vo.setKIKAKUNO(_condition.getKikakuno());
            vo.setCAMPAIGN(_condition.getCampaign());
            vo.setNAIYOHIMOKU(_condition.getNaiyohimoku());
            vo.setSPACE(_condition.getSpace());
            vo.setNPDIVISION(_condition.getNpdivision());
            vo.setPUBLISHVER(_condition.getPublishver());
            vo.setSYMBOLDIVISION(_condition.getSymboldivision());
            vo.setPOSTEDSURFACE(_condition.getPostedsurface());
            vo.setUNIT(_condition.getUnit());
            vo.setCONTRACTDIVISION(_condition.getContractdivision());
            vo.setKIKANFROM(_condition.getKikanfrom());
            vo.setKIKANTO(_condition.getKikanto());
            vo.setGENKAFLG(_condition.getGenkaflg());
            vo.setGROSS(_condition.getGross());
            vo.setDNEBIKIRITSU(_condition.getDnebikiritsu());
            vo.setDNEBIKIGAKU(_condition.getDnebikigaku());
            vo.setHMCOST(_condition.getHmcost());
            vo.setAPLRIEKIRITSU(_condition.getAplriekiritsu());
            vo.setAPLRIEKIGAKU(_condition.getAplriekigaku());
            vo.setMEDIAHARAI(_condition.getMediaharai());
            vo.setMEDIAMARGINRITSU(_condition.getMediamarginritsu());
            vo.setMEDIAMARGINGAKU(_condition.getMediamargingaku());
            vo.setMEDIAGENKA(_condition.getMediagenka());
            vo.setTORIRIEKI(_condition.getToririeki());
            vo.setRIEKIHAIBUN(_condition.getRiekihaibun());
            vo.setNAIKINRIEKI(_condition.getNaikinrieki());
            vo.setFURIKAERIEKI(_condition.getFurikaerieki());
            vo.setEIGYOYOIN(_condition.getEigyoyoin());
            vo.setFURIKAERIEKI2(_condition.getFurikaerieki2());
            vo.setTVTMEDIATANKA(_condition.getTvtmediatanka());
            vo.setTVTHMTANKA(_condition.getTvthmtanka());
            vo.setCOLORFEE(_condition.getColorfee());
            vo.setDESIGNATIONFEE(_condition.getDesignationfee());
            vo.setDOUBLEFEE(_condition.getDoublefee());
            vo.setRECLASSIFICATIONFEE(_condition.getReclassificationfee());
            vo.setSPACEFEE(_condition.getSpacefee());
            vo.setSPLITRUNFEE(_condition.getSplitrunfee());
            vo.setREQUESTDESTINATION(_condition.getRequestdestination());
            vo.setBRDDATE(_condition.getBrddate());
            vo.setBIKO(_condition.getBiko());
            vo.setSEIKYUFLG(_condition.getSeikyuflg());
            vo.setCPDATE(_condition.getCpdate());
            vo.setBRDSEC(_condition.getBrdsec());
            vo.setFILEOUTFLG(_condition.getFileoutflg());
            vo.setAPPEARANCEDATE(_condition.getAppearancedate());
            vo.setSORTNO(_condition.getSortno());
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

        orderSql.append(" ORDER BY ");
        orderSql.append(" " + Tbj02EigyoDaicho.SORTNO + " ");

        return selectSql.toString() + whereSqlStr + orderSql.toString();
    }

    /**�c�ƍ�Ƒ䒠MAX�l�擾*/
    private String getMaxDaichoNoSQLByCondition() {

         StringBuffer sql = new StringBuffer();

         sql.append("SELECT ");
         sql.append(" NVL(MAX(" + Tbj02EigyoDaicho.MEDIAPLANNO + "),0)AS " +Tbj02EigyoDaicho.MEDIAPLANNO+"," );
         sql.append(" TO_CHAR(NVL(MAX(TO_NUMBER(" + Tbj02EigyoDaicho.DAICHONO + ")),0)) AS " + Tbj02EigyoDaicho.DAICHONO);
         sql.append(" FROM ");
         sql.append(" " + getTableName() + " ");

         return sql.toString();
    }

    /**
     * �}�̊Ǘ�No�ɂ��c�ƍ�Ƒ䒠�f�[�^����
     * @return SQL��
     */
    private String getEigyoDaichoByMediaPlanNo() {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        sql.append(" * ");
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIAPLANNO + " = " + _mediaPlanNo + " ");


        return sql.toString();
    }

    private String getLastUpdateDaicho()
    {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        sql.append(" " +Tbj02EigyoDaicho.UPDDATE + ", ");
        sql.append(" " +Tbj02EigyoDaicho.UPDNM + " ");
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" TO_CHAR(" +Tbj02EigyoDaicho.SEIKYUYM + ",'YYYY/MM') = '" + _seikyuYM + "' ");
        sql.append(" ORDER BY ");
        sql.append(" " + Tbj02EigyoDaicho.UPDDATE + " DESC ");

        return sql.toString();

    }

    /**
     * �䒠No�ɂ�錟�����s��
     * @return SQL��
     */
    private String getEigyoDaichoByDaichoNo() {
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
        sql.append(" " + Tbj02EigyoDaicho.DAICHONO + " ='" + _daichoNo + "' ");
        return sql.toString();
    }

    /**
     * �c�ƍ�Ƒ䒠�̗������v���擾
     * @return SQL��
     */
    private String getEigyoDaichoFeeSUM() {
        StringBuffer sql = new StringBuffer();
        sql.append(" SELECT ");
        sql.append(" NVL(SUM(" + Tbj02EigyoDaicho.GROSS + "),0) AS " + Tbj02EigyoDaicho.GROSS + ", ");
        sql.append(" NVL(SUM(" + Tbj02EigyoDaicho.HMCOST + "),0) AS " +Tbj02EigyoDaicho.HMCOST + " ");
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj02EigyoDaicho.MEDIAPLANNO + " ='" + _mediaPlanNo + "' ");

        return sql.toString();
    }

    /**
     * �c�ƍ�Ƒ䒠�̃\�[�g���̍ő�l���擾
     * @return SQL��
     */
    private String getMaxSortNo() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        sql.append("NVL(MAX(" + Tbj02EigyoDaicho.SORTNO + "), 0) AS " + Tbj02EigyoDaicho.SORTNO);
        sql.append(" FROM ");
        sql.append(getTableName());
        sql.append(" WHERE ");
        sql.append(Tbj02EigyoDaicho.KIKANFROM + " >= " + getDBModelInterface().ConvertToDBString(_condition.getKikanfrom()));
        sql.append(" AND ");
        sql.append(Tbj02EigyoDaicho.KIKANTO + " <= " + getDBModelInterface().ConvertToDBString(_condition.getKikanto()));

        return sql.toString();
    }

    /**
     * InsertVO
     * @param vo �f�[�^
     * @throws HAMException
     */
    public void insertVO(Tbj02EigyoDaichoVO vo) throws HAMException {

        // �p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�o�^�G���[", "BJ-E0002");
        }
        super.setModel(vo);

        try {
            if (!super.insert()) {
                throw new HAMException("�o�^�G���[", "BJ-E0002");
            }
        } catch(UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * UpdateVO
     * @param vo �f�[�^
     * @throws HAMException
     */
    public void updateVO(Tbj02EigyoDaichoVO vo) throws HAMException {

        // �p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�X�V�G���[", "BJ-E0003");
        }
        super.setModel(vo);

        try {
            if (!super.update()) {
                throw new HAMException("�X�V�G���[", "BJ-E0003");
            }
        } catch(UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * DeleteVO
     * @param vo �f�[�^
     * @throws HAMException
     */
    public void deleteVO(Tbj02EigyoDaichoVO vo) throws HAMException {

        // �p�����[�^�`�F�b�N
        if (vo == null) {
            throw new HAMException("�폜�G���[", "BJ-E0004");
        }
        super.setModel(vo);

        try {
            if (!super.remove()) {
                throw new HAMException("�폜�G���[", "BJ-E0004");
            }
        } catch(ConcurrentUpdateException e) {
            //���������u0�v�̏ꍇ

            //����Ƃ���(�폜���R�[�h�Ȃ�)
            return;
        } catch(UpdateFailureException e) {
            // ���������u2�ȏ�v�̏ꍇ

            //����Ƃ���
            return;
        } catch(UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    /**
     * SelectVO
     * @param contion ��������
     * @return �擾�f�[�^
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj02EigyoDaichoVO> selectVO(Tbj02EigyoDaichoCondition condition) throws HAMException {

        // �p�����[�^�`�F�b�N
        if (condition == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }

        super.setModel(new Tbj02EigyoDaichoVO());
        _condition = condition;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * ��Ƒ䒠NO�ő�l�擾
     * @param contion ��������
     * @return �擾�f�[�^
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj02EigyoDaichoVO> selectMaxDaichoNo() throws HAMException {

        super.setModel(new Tbj02EigyoDaichoVO());

        try {
            _sqlMode = SqlMode.MAX;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �ŏI�X�V���擾
     * @param contion ��������
     * @return �擾�f�[�^
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj02EigyoDaichoVO> FindLastUpdate(String seikyuYM) throws HAMException {

        super.setModel(new Tbj02EigyoDaichoVO());

        try {
            _seikyuYM = seikyuYM;
            _sqlMode = SqlMode.LAST;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �}�̊Ǘ�No�ɂ�錟��
     * @param �}�̊Ǘ�No
     * @return �擾�f�[�^
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj02EigyoDaichoVO> FindEigyoDaichoByMediaPlanNo(String mediaPlanNo) throws HAMException {

        super.setModel(new Tbj02EigyoDaichoVO());

        try {
            _sqlMode = SqlMode.BYMEDIAPLANNO;
            _mediaPlanNo = mediaPlanNo;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �䒠No�ɂ�錟��
     * @param �䒠No
     * @return �擾�f�[�^
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj02EigyoDaichoVO> FindEigyoDaichoByDaichoNo(String daichoNo) throws HAMException {

        super.setModel(new Tbj02EigyoDaichoVO());

        try {
            _sqlMode = SqlMode.BYDAICHONO;
            _daichoNo = daichoNo;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �}�̏󋵊Ǘ�NO�ɑ΂���c�ƍ�Ƒ䒠�̗������v���擾
     * @param mediaPlanNo �}�̏󋵊Ǘ�No
     * @return �擾�f�[�^
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj02EigyoDaichoVO> FindEigyoDaichoFeeSUM(String mediaPlanNo) throws HAMException {

        super.setModel(new Tbj02EigyoDaichoVO());

        try {
            _sqlMode = SqlMode.SUM;
            _mediaPlanNo = mediaPlanNo;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �\�[�g���̍ő�l���擾
     * @param condition �擾����
     * @return �擾�f�[�^
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj02EigyoDaichoVO> FindMaxSortNo(Tbj02EigyoDaichoCondition condition) throws HAMException {

        super.setModel(new Tbj02EigyoDaichoVO());

        try {
            _sqlMode = SqlMode.SORTNO;
            _condition = condition;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
