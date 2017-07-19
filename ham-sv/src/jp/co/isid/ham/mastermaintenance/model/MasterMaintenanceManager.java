package jp.co.isid.ham.mastermaintenance.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

import jp.co.isid.ham.common.model.*;
import jp.co.isid.ham.integ.tbl.Mbj01SysSts;
import jp.co.isid.ham.integ.tbl.Mbj02User;
import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj04Keiretsu;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj06HcBumon;
import jp.co.isid.ham.integ.tbl.Mbj07HcUser;
import jp.co.isid.ham.integ.tbl.Mbj08HcProduct;
import jp.co.isid.ham.integ.tbl.Mbj09Hiyou;
import jp.co.isid.ham.integ.tbl.Mbj10MediaSec;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.Mbj13CarOutCtrl;
import jp.co.isid.ham.integ.tbl.Mbj14MediaOutCtrl;
import jp.co.isid.ham.integ.tbl.Mbj20CarCategory;
import jp.co.isid.ham.integ.tbl.Mbj22CategoryContent;
import jp.co.isid.ham.integ.tbl.Mbj23CarTanto;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Mbj27MediaProduct;
import jp.co.isid.ham.integ.tbl.Mbj29SetteiKyk;
import jp.co.isid.ham.integ.tbl.Mbj30InputTnt;
import jp.co.isid.ham.integ.tbl.Mbj31Information;
import jp.co.isid.ham.integ.tbl.Mbj32Department;
import jp.co.isid.ham.integ.tbl.Mbj33FunctionControl;
import jp.co.isid.ham.integ.tbl.Mbj34FunctionControlItem;
import jp.co.isid.ham.integ.tbl.Mbj35MediaPattern;
import jp.co.isid.ham.integ.tbl.Mbj36MediaPatternItem;
import jp.co.isid.ham.integ.tbl.Mbj40AlertMailAddress;
import jp.co.isid.ham.integ.tbl.Mbj41AlertDispControl;
import jp.co.isid.ham.integ.tbl.Mbj42Security;
import jp.co.isid.ham.integ.tbl.Mbj43SecurityItem;
import jp.co.isid.ham.integ.tbl.Mbj44SecurityBase;
import jp.co.isid.ham.integ.tbl.Mbj47Newspaper;
import jp.co.isid.ham.integ.tbl.Mbj48HmUser;
import jp.co.isid.ham.integ.tbl.Mbj52SzTntUser;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.constants.HAMConstants;

/**
 * <P>
 * �}�X�^�����e�i���XManager
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/04 �X)<BR>
 * �E�����Ɩ��ύX�Ή�(2015/08/31 HLC S,Fujimoto)<BR>
 * �EHDX�Ή�(2016/02/17 HLC K.Oki)<BR>
 * </P>
 * @author �X
 */
public class MasterMaintenanceManager
{
    /** �V���O���g���C���X�^���X */
    private static MasterMaintenanceManager _manager = new MasterMaintenanceManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private MasterMaintenanceManager()
    {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static MasterMaintenanceManager getInstance() {
        return _manager;
    }

    /**
     * �ߋ����b�N�o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceLock(RegistMbj01SysStsVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj01SysSts.TBNAME,Mbj01SysSts.PREFIX);
        Mbj01SysStsDAO dao = Mbj01SysStsDAOFactory.createMbj01SysStsDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �ߋ����b�N�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj01SysStsVO getMasterMaintenanceLock(Mbj01SysStsCondition condition) throws HAMException {

        FindMbj01SysStsVO vo = new FindMbj01SysStsVO();

        if (condition != null) {
            Mbj01SysStsDAO dao = Mbj01SysStsDAOFactory.createMbj01SysStsDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �S���ғo�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceUser(RegistMbj02UserVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj02User.TBNAME,Mbj02User.PREFIX);
        Mbj02UserDAO dao = Mbj02UserDAOFactory.createMbj02UserDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �S���Ҍ����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj02UserVO getMasterMaintenanceUser(Mbj02UserCondition condition) throws HAMException {

        FindMbj02UserVO vo = new FindMbj02UserVO();

        if (condition != null) {
            Mbj02UserDAO dao = Mbj02UserDAOFactory.createMbj02UserDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �Ԏ팠���o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceCarAuthority(RegistMbj11CarSecVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusionHamId(vo.getExclusion(),Mbj11CarSec.TBNAME,Mbj11CarSec.PREFIX);
        Mbj11CarSecDAO dao = Mbj11CarSecDAOFactory.createMbj11CarSecDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �Ԏ팠�������f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj11CarSecVO getMasterMaintenanceCarAuthority(Mbj11CarSecCondition condition) throws HAMException {

        FindMbj11CarSecVO vo = new FindMbj11CarSecVO();

        if (condition != null) {
            Mbj11CarSecDAO dao = Mbj11CarSecDAOFactory.createMbj11CarSecDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �}�̌����o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceMediaAuthority(RegistMbj10MediaSecVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusionHamId(vo.getExclusion(),Mbj10MediaSec.TBNAME,Mbj10MediaSec.PREFIX);
        Mbj10MediaSecDAO dao = Mbj10MediaSecDAOFactory.createMbj10MediaSecDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �}�̌��������f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj10MediaSecVO getMasterMaintenanceMediaAuthority(Mbj10MediaSecCondition condition) throws HAMException
    {
        FindMbj10MediaSecVO vo = new FindMbj10MediaSecVO();

        if (condition != null) {
            Mbj10MediaSecDAO dao = Mbj10MediaSecDAOFactory.createMbj10MediaSecDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �n��o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceSeries(RegistMbj04KeiretsuVO vo) throws HAMException
    {
        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj04Keiretsu.TBNAME,Mbj04Keiretsu.PREFIX);
        checkRegistMasterMaintenanceSeries(vo);
        Mbj04KeiretsuDAO dao = Mbj04KeiretsuDAOFactory.createMbj04KeiretsuDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �n�񌟍��f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj04KeiretsuVO getMasterMaintenanceSeries(Mbj04KeiretsuCondition condition) throws HAMException {

        FindMbj04KeiretsuVO vo = new FindMbj04KeiretsuVO();

        if (condition != null) {
            Mbj04KeiretsuDAO dao = Mbj04KeiretsuDAOFactory.createMbj04KeiretsuDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �Ԏ�o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceCar(RegistMbj05CarVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj05Car.TBNAME,Mbj05Car.PREFIX);
        Mbj05CarDAO dao = Mbj05CarDAOFactory.createMbj05CarDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �Ԏ팟���f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj05CarVO getMasterMaintenanceCar(Mbj05CarCondition condition) throws HAMException {

        FindMbj05CarVO vo = new FindMbj05CarVO();

        if (condition != null) {
            Mbj05CarDAO dao = Mbj05CarDAOFactory.createMbj05CarDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �Ԏ�o�͐ݒ�o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceCarOutControl(RegistMbj13CarOutCtrlVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj13CarOutCtrl.TBNAME,Mbj13CarOutCtrl.PREFIX);
        Mbj13CarOutCtrlDAO dao = Mbj13CarOutCtrlDAOFactory.createMbj13CarOutCtrlDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �Ԏ�o�͐ݒ茟���f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj13CarOutCtrlVO getMasterMaintenanceCarOutControl(Mbj13CarOutCtrlCondition condition) throws HAMException {

        FindMbj13CarOutCtrlVO vo = new FindMbj13CarOutCtrlVO();

        if (condition != null) {
            Mbj13CarOutCtrlDAO dao = Mbj13CarOutCtrlDAOFactory.createMbj13CarOutCtrlDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �}�̓o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceMedia(RegistMbj03MediaVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj03Media.TBNAME,Mbj03Media.PREFIX);
        Mbj03MediaDAO dao = Mbj03MediaDAOFactory.createMbj03MediaDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �}�̌����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj03MediaVO getMasterMaintenanceMedia(Mbj03MediaCondition condition) throws HAMException {

        FindMbj03MediaVO vo = new FindMbj03MediaVO();

        if (condition != null) {
            Mbj03MediaDAO dao = Mbj03MediaDAOFactory.createMbj03MediaDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;

    }

    /**
     * �}�̏o�͐ݒ�o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceMediaOutControl(RegistMbj14MediaOutCtrlVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj14MediaOutCtrl.TBNAME,Mbj14MediaOutCtrl.PREFIX);
        Mbj14MediaOutCtrlDAO dao = Mbj14MediaOutCtrlDAOFactory.createMbj14MediaOutCtrlDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �}�̏o�͐ݒ茟���f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj14MediaOutCtrlVO getMasterMaintenanceMediaOutControl(Mbj14MediaOutCtrlCondition condition) throws HAMException {

        FindMbj14MediaOutCtrlVO vo = new FindMbj14MediaOutCtrlVO();

        if (condition != null) {
            Mbj14MediaOutCtrlDAO dao = Mbj14MediaOutCtrlDAOFactory.createMbj14MediaOutCtrlDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * ��p���No�o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceCostPlan(RegistMbj09HiyouVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj09Hiyou.TBNAME,Mbj09Hiyou.PREFIX);
        Mbj09HiyouDAO dao = Mbj09HiyouDAOFactory.createMbj09HiyouDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * ��p���No�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj09HiyouVO getMasterMaintenanceCostPlan(Mbj09HiyouCondition condition) throws HAMException {

        FindMbj09HiyouVO vo = new FindMbj09HiyouVO();

        if (condition != null) {
            Mbj09HiyouDAO dao = Mbj09HiyouDAOFactory.createMbj09HiyouDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �Ԏ�J�e�S���o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceCarCategory(RegistMbj20CarCategoryVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj20CarCategory.TBNAME,Mbj20CarCategory.PREFIX);
        Mbj20CarCategoryDAO dao = Mbj20CarCategoryDAOFactory.createMbj20CarCategoryDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �Ԏ�J�e�S�������f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj20CarCategoryVO getMasterMaintenanceCarCategory(Mbj20CarCategoryCondition condition) throws HAMException {

        FindMbj20CarCategoryVO vo = new FindMbj20CarCategoryVO();

        if (condition != null) {
            Mbj20CarCategoryDAO dao = Mbj20CarCategoryDAOFactory.createMbj20CarCategoryDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �Ԏ�J�e�S���R�t�o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceCarCategoryContent(RegistMbj22CategoryContentVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj22CategoryContent.TBNAME,Mbj22CategoryContent.PREFIX);

        if (vo.getInsertList() != null) {
            MasterMaintenanceCheckDao checkDao = MasterMaintenanceCheckDaoFactory.createMasterMaintenanceCheckDao();
            checkDao.checkRegistMasterMaintenanceCarCategoryContent(vo.getInsertList());
        }

        Mbj22CategoryContentDAO dao = Mbj22CategoryContentDAOFactory.createMbj22CategoryContentDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �Ԏ�J�e�S���R�t�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj22CategoryContentVO getMasterMaintenanceCarCategoryContent(Mbj22CategoryContentCondition condition) throws HAMException {

        FindMbj22CategoryContentVO vo = new FindMbj22CategoryContentVO();

        if (condition != null) {
            Mbj22CategoryContentDAO dao = Mbj22CategoryContentDAOFactory.createMbj22CategoryContentDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �Ԏ�S���o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceCarUser(RegistMbj23CarTantoVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj23CarTanto.TBNAME,Mbj23CarTanto.PREFIX);
        Mbj23CarTantoDAO dao = Mbj23CarTantoDAOFactory.createMbj23CarTantoDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �Ԏ�S�������f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj23CarTantoVO getMasterMaintenanceCarUser(Mbj23CarTantoCondition condition) throws HAMException {

        FindMbj23CarTantoVO vo = new FindMbj23CarTantoVO();

        if (condition != null) {
            Mbj23CarTantoDAO dao = Mbj23CarTantoDAOFactory.createMbj23CarTantoDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * ������O���[�v�o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceDemandGroup(RegistMbj26BillGroupVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj26BillGroup.TBNAME,Mbj26BillGroup.PREFIX);
        checkRegistMasterMaintenanceDemandGroup(vo);
        Mbj26BillGroupDAO dao = Mbj26BillGroupDAOFactory.createMbj26BillGroupDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * ������O���[�v�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj26BillGroupVO getMasterMaintenanceDemandGroup(Mbj26BillGroupCondition condition) throws HAMException {

        FindMbj26BillGroupVO vo = new FindMbj26BillGroupVO();

        if (condition != null) {
            Mbj26BillGroupDAO dao = Mbj26BillGroupDAOFactory.createMbj26BillGroupDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * HC����o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceHCSection(RegistMbj06HcBumonVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj06HcBumon.TBNAME,Mbj06HcBumon.PREFIX);
        checkRegistMasterMaintenanceHCSection(vo);
        Mbj06HcBumonDAO dao = Mbj06HcBumonDAOFactory.createMbj06HcBumonDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * HC���匟���f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj06HcBumonVO getMasterMaintenanceHCSection(Mbj06HcBumonCondition condition) throws HAMException {

        FindMbj06HcBumonVO vo = new FindMbj06HcBumonVO();

        if (condition != null) {
            Mbj06HcBumonDAO dao = Mbj06HcBumonDAOFactory.createMbj06HcBumonDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * HC�S���ғo�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceHCUser(RegistMbj07HcUserVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj07HcUser.TBNAME,Mbj07HcUser.PREFIX);
        Mbj07HcUserDAO dao = Mbj07HcUserDAOFactory.createMbj07HcUserDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * HC�S���Ҍ����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj07HcUserVO getMasterMaintenanceHCUser(Mbj07HcUserCondition condition) throws HAMException {

        FindMbj07HcUserVO vo = new FindMbj07HcUserVO();

        if (condition != null) {
            Mbj07HcUserDAO dao = Mbj07HcUserDAOFactory.createMbj07HcUserDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * HC���i�o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceHCProduct(RegistMbj08HcProductVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj08HcProduct.TBNAME,Mbj08HcProduct.PREFIX);
        Mbj08HcProductDAO dao = Mbj08HcProductDAOFactory.createMbj08HcProductDAO();

        // ���R�[�h�S�폜
        dao.allDelete();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * HC���i�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj08HcProductVO getMasterMaintenanceHCProduct(Mbj08HcProductCondition condition) throws HAMException {

        FindMbj08HcProductVO vo = new FindMbj08HcProductVO();

        if (condition != null) {
            Mbj08HcProductDAO dao = Mbj08HcProductDAOFactory.createMbj08HcProductDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �}�́E���i�R�t�o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceMediaProduct(RegistMbj27MediaProductVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj27MediaProduct.TBNAME,Mbj27MediaProduct.PREFIX);
        Mbj27MediaProductDAO dao = Mbj27MediaProductDAOFactory.createMbj27MediaProductDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �}�́E���i�R�t�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj27MediaProductVO getMasterMaintenanceMediaProduct(Mbj27MediaProductCondition condition) throws HAMException {

        FindMbj27MediaProductVO vo = new FindMbj27MediaProductVO();

        if (condition != null) {
            Mbj27MediaProductDAO dao = Mbj27MediaProductDAOFactory.createMbj27MediaProductDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �ݒ�Ǔo�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceEstablishmentOffice(RegistMbj29SetteiKykVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj29SetteiKyk.TBNAME,Mbj29SetteiKyk.PREFIX);
        checkRegistMasterMaintenanceEstablishmentOffice(vo);
        Mbj29SetteiKykDAO dao = Mbj29SetteiKykDAOFactory.createMbj29SetteiKykDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �ݒ�ǌ����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj29SetteiKykVO getMasterMaintenanceEstablishmentOffice(Mbj29SetteiKykCondition condition) throws HAMException {

        FindMbj29SetteiKykVO vo = new FindMbj29SetteiKykVO();

        if (condition != null) {
            Mbj29SetteiKykDAO dao = Mbj29SetteiKykDAOFactory.createMbj29SetteiKykDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * ���͒S���o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceInputUser(RegistMbj30InputTntVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj30InputTnt.TBNAME,Mbj30InputTnt.PREFIX);
        checkRegistMasterMaintenanceInputUser(vo);
        Mbj30InputTntDAO dao = Mbj30InputTntDAOFactory.createMbj30InputTntDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * ���͒S���o�^�f�[�^VO�폜�i�d�ʎԎ�R�[�h�w��j
     *
     * @param vo �f�[�^VO
     */
    public void deleteMasterMaintenanceInputUserDCARCD(RegistMbj30InputTntVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj30InputTnt.TBNAME,Mbj30InputTnt.PREFIX);
        Mbj30InputTntDAO dao = Mbj30InputTntDAOFactory.createMbj30InputTntDAO();
        MasterMaintenanceCheckDao checkDao = MasterMaintenanceCheckDaoFactory.createMasterMaintenanceCheckDao();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            Mbj30InputTntCondition mbj30condition = new Mbj30InputTntCondition();
            mbj30condition.setDcarcd(vo.getDeleteList().get(i).getDCARCD());
            List<Mbj30InputTntVO> checkListMbj30VO = dao.selectVO(mbj30condition);

            for (int j = 0 ; (checkListMbj30VO != null) && (j < checkListMbj30VO.size()) ; j++) {
                List<Mbj30InputTntVO> workListMbj30VO = new ArrayList<Mbj30InputTntVO>();
                workListMbj30VO.add(checkListMbj30VO.get(j));

                try {
                    checkDao.checkDeleteMasterMaintenanceInputUser(workListMbj30VO);
                } catch(HAMException e) {
                    if (!e.getErrorID().equals("BJ-W0047")) {
                        throw e;
                    }

                    continue;
                }

                dao.deleteVO(checkListMbj30VO.get(j));
            }
        }
    }

    /**
     * ���͒S�������f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj30InputTntVO getMasterMaintenanceInputUser(Mbj30InputTntCondition condition) throws HAMException {

        FindMbj30InputTntVO vo = new FindMbj30InputTntVO();

        if (condition != null) {
            Mbj30InputTntDAO dao = Mbj30InputTntDAOFactory.createMbj30InputTntDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �@�\����o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceFunctionControl(RegistMbj33FunctionControlVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusionHamId(vo.getExclusion(),Mbj33FunctionControl.TBNAME,Mbj33FunctionControl.PREFIX);
        Mbj33FunctionControlDAO dao = Mbj33FunctionControlDAOFactory.createMbj33FunctionControlDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �@�\���䌟���f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj33FunctionControlVO getMasterMaintenanceFunctionControl(Mbj33FunctionControlCondition condition) throws HAMException {

        FindMbj33FunctionControlVO vo = new FindMbj33FunctionControlVO();

        if (condition != null) {
            Mbj33FunctionControlDAO dao = Mbj33FunctionControlDAOFactory.createMbj33FunctionControlDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �@�\���䍀�ړo�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceFunctionControlItem(RegistMbj34FunctionControlItemVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj34FunctionControlItem.TBNAME,Mbj34FunctionControlItem.PREFIX);
        Mbj34FunctionControlItemDAO dao = Mbj34FunctionControlItemDAOFactory.createMbj34FunctionControlItemDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �@�\���䍀�ڌ����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj34FunctionControlItemVO getMasterMaintenanceFunctionControlItem(Mbj34FunctionControlItemCondition condition) throws HAMException {

        FindMbj34FunctionControlItemVO vo = new FindMbj34FunctionControlItemVO();

        if (condition != null) {
            Mbj34FunctionControlItemDAO dao = Mbj34FunctionControlItemDAOFactory.createMbj34FunctionControlItemDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �@�\����x�[�X�o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceFunctionControlBase(RegistMbj39FunctionControlBaseVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj34FunctionControlItem.TBNAME,Mbj34FunctionControlItem.PREFIX);
        Mbj39FunctionControlBaseDAO dao = Mbj39FunctionControlBaseDAOFactory.createMbj39FunctionControlBaseDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �@�\����x�[�X�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj39FunctionControlBaseVO getMasterMaintenanceFunctionControlBase(Mbj39FunctionControlBaseCondition condition) throws HAMException {

        FindMbj39FunctionControlBaseVO vo = new FindMbj39FunctionControlBaseVO();

        if (condition != null) {
            Mbj39FunctionControlBaseDAO dao = Mbj39FunctionControlBaseDAOFactory.createMbj39FunctionControlBaseDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �C���t�H���[�V�����o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceInformation(RegistMbj31InformationVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj31Information.TBNAME,Mbj31Information.PREFIX);
        Mbj31InformationDAO dao = Mbj31InformationDAOFactory.createMbj31InformationDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �C���t�H���[�V���������f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj31InformationVO getMasterMaintenanceInformation(Mbj31InformationCondition condition) throws HAMException {

        FindMbj31InformationVO vo = new FindMbj31InformationVO();

        if (condition != null) {
            Mbj31InformationDAO dao = Mbj31InformationDAOFactory.createMbj31InformationDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �����o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceDepartment(RegistMbj32DepartmentVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj32Department.TBNAME,Mbj32Department.PREFIX);
        Mbj32DepartmentDAO dao = Mbj32DepartmentDAOFactory.createMbj32DepartmentDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * ���������f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj32DepartmentVO getMasterMaintenanceDepartment(Mbj32DepartmentCondition condition) throws HAMException {

        FindMbj32DepartmentVO vo = new FindMbj32DepartmentVO();

        if (condition != null) {
            Mbj32DepartmentDAO dao = Mbj32DepartmentDAOFactory.createMbj32DepartmentDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �}�̃p�^�[���o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceMediaPattern(RegistMbj35MediaPatternVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj35MediaPattern.TBNAME,Mbj35MediaPattern.PREFIX);
        Mbj35MediaPatternDAO dao = Mbj35MediaPatternDAOFactory.createMbj35MediaPatternDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �}�̃p�^�[�������f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj35MediaPatternVO getMasterMaintenanceMediaPattern(Mbj35MediaPatternCondition condition) throws HAMException {

        FindMbj35MediaPatternVO vo = new FindMbj35MediaPatternVO();

        if (condition != null) {
            Mbj35MediaPatternDAO dao = Mbj35MediaPatternDAOFactory.createMbj35MediaPatternDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �}�̃p�^�[�����e�o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceMediaPatternItem(RegistMbj36MediaPatternItemVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj36MediaPatternItem.TBNAME,Mbj36MediaPatternItem.PREFIX);
        Mbj36MediaPatternItemDAO dao = Mbj36MediaPatternItemDAOFactory.createMbj36MediaPatternItemDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �}�̃p�^�[�����e�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj36MediaPatternItemVO getMasterMaintenanceMediaPatternItem(Mbj36MediaPatternItemCondition condition) throws HAMException {

        FindMbj36MediaPatternItemVO vo = new FindMbj36MediaPatternItemVO();

        if (condition != null) {
            Mbj36MediaPatternItemDAO dao = Mbj36MediaPatternItemDAOFactory.createMbj36MediaPatternItemDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �R�[�h�}�X�^�o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceCode(RegistMbj12CodeVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj12Code.TBNAME,Mbj12Code.PREFIX);
        Mbj12CodeDAO dao = Mbj12CodeDAOFactory.createMbj12CodeDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �R�[�h�}�X�^�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj12CodeVO getMasterMaintenanceCode(Mbj12CodeCondition condition) throws HAMException {

        FindMbj12CodeVO vo = new FindMbj12CodeVO();

        if (condition != null) {
            Mbj12CodeDAO dcDao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
            vo.setFindList(dcDao.selectVO(condition));
        }

        return vo;
    }

    /**
     * ���[���z�M�}�X�^�o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceAlertMailAddress(RegistMbj40AlertMailAddressVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj40AlertMailAddress.TBNAME,Mbj40AlertMailAddress.PREFIX);
        Mbj40AlertMailAddressDAO dao = Mbj40AlertMailAddressDAOFactory.createMbj40AlertMailAddressDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * ���[���z�M�}�X�^�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj40AlertMailAddressVO getMasterMaintenanceAlertMailAddress(Mbj40AlertMailAddressCondition condition) throws HAMException {

        FindMbj40AlertMailAddressVO vo = new FindMbj40AlertMailAddressVO();

        if (condition != null) {
            Mbj40AlertMailAddressDAO dcDao = Mbj40AlertMailAddressDAOFactory.createMbj40AlertMailAddressDAO();
            vo.setFindList(dcDao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �A���[�g�\������}�X�^�o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceAlertDispControl(RegistMbj41AlertDispControlVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj41AlertDispControl.TBNAME,Mbj41AlertDispControl.PREFIX);
        Mbj41AlertDispControlDAO dao = Mbj41AlertDispControlDAOFactory.createMbj41AlertDispControlDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVOWhereNoPrimaryKey(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �A���[�g�\������}�X�^�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj41AlertDispControlVO getMasterMaintenanceAlertDispControl(Mbj41AlertDispControlCondition condition) throws HAMException {

        FindMbj41AlertDispControlVO vo = new FindMbj41AlertDispControlVO();

        if (condition != null) {
            Mbj41AlertDispControlDAO dcDao = Mbj41AlertDispControlDAOFactory.createMbj41AlertDispControlDAO();
            vo.setFindList(dcDao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �Z�L�����e�B�o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceSecurity(RegistMbj42SecurityVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusionHamId(vo.getExclusion(),Mbj42Security.TBNAME,Mbj42Security.PREFIX);
        Mbj42SecurityDAO dao = Mbj42SecurityDAOFactory.createMbj42SecurityDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �Z�L�����e�B�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj42SecurityVO getMasterMaintenanceSecurity(Mbj42SecurityCondition condition) throws HAMException {

        FindMbj42SecurityVO vo = new FindMbj42SecurityVO();

        if (condition != null) {
            Mbj42SecurityDAO dao = Mbj42SecurityDAOFactory.createMbj42SecurityDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �Z�L�����e�B���ڃ}�X�^�o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceSecurityItem(RegistMbj43SecurityItemVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj43SecurityItem.TBNAME,Mbj43SecurityItem.PREFIX);
        Mbj43SecurityItemDAO dao = Mbj43SecurityItemDAOFactory.createMbj43SecurityItemDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �Z�L�����e�B���ڃ}�X�^�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj43SecurityItemVO getMasterMaintenanceSecurityItem(Mbj43SecurityItemCondition condition) throws HAMException {

        FindMbj43SecurityItemVO vo = new FindMbj43SecurityItemVO();

        if (condition != null) {
            Mbj43SecurityItemDAO dcDao = Mbj43SecurityItemDAOFactory.createMbj43SecurityItemDAO();
            vo.setFindList(dcDao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �Z�L�����e�B�x�[�X�}�X�^�o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceSecurityBase(RegistMbj44SecurityBaseVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj44SecurityBase.TBNAME,Mbj44SecurityBase.PREFIX);
        Mbj44SecurityBaseDAO dao = Mbj44SecurityBaseDAOFactory.createMbj44SecurityBaseDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �Z�L�����e�B�x�[�X�}�X�^�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj44SecurityBaseVO getMasterMaintenanceSecurityBase(Mbj44SecurityBaseCondition condition) throws HAMException {

        FindMbj44SecurityBaseVO vo = new FindMbj44SecurityBaseVO();

        if (condition != null) {
            Mbj44SecurityBaseDAO dcDao = Mbj44SecurityBaseDAOFactory.createMbj44SecurityBaseDAO();
            vo.setFindList(dcDao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �V���}�X�^�o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceNewspaper(RegistMbj47NewspaperVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj47Newspaper.TBNAME,Mbj47Newspaper.PREFIX);
        Mbj47NewspaperDAO dao = Mbj47NewspaperDAOFactory.createMbj47NewspaperDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * �V���}�X�^�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMbj47NewspaperVO getMasterMaintenanceNewspaper(Mbj47NewspaperCondition condition) throws HAMException {

        FindMbj47NewspaperVO vo = new FindMbj47NewspaperVO();

        if (condition != null) {
            Mbj47NewspaperDAO dcDao = Mbj47NewspaperDAOFactory.createMbj47NewspaperDAO();
            vo.setFindList(dcDao.selectVO(condition));
        }

        return vo;
    }

    /* 2015/08/31 �����Ɩ��ύX�Ή� HLC S.Fujimoto ADD Start */
    /**
     * HM�S���ғo�^�f�[�^VO�o�^
     * @param vo HM�S���ғo�^�f�[�^VO
     * @throws HAMException
     */
    public void registMasterMaintenanceHMUser(RegistMbj48HmUserVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(), Mbj48HmUser.TBNAME, Mbj48HmUser.PREFIX);
        Mbj48HmUserDAO dao = Mbj48HmUserDAOFactory.createMbj48HmUserDAO();

        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }
        for (int i = 0 ; (vo.getInsertList() != null) && (i < vo.getInsertList().size()) ; i++) {
            dao.insertVO(vo.getInsertList().get(i));
        }
        for (int i = 0 ; (vo.getUpdateList() != null) && (i < vo.getUpdateList().size()) ; i++) {
            dao.updateVO(vo.getUpdateList().get(i));
        }
    }

    /**
     * HC�S���Ҍ����f�[�^VO�擾
     * @param condition ��������
     * @return �����f�[�^VO
     * @throws HAMException
     */
    public FindMbj48HmUserVO getMasterMaintenanceHMUser(Mbj48HmUserCondition condition) throws HAMException {

        FindMbj48HmUserVO vo = new FindMbj48HmUserVO();

        if (condition != null) {
            Mbj48HmUserDAO dao = Mbj48HmUserDAOFactory.createMbj48HmUserDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /**
     * �}��(����)�����f�[�^VO�擾
     * @param condition ��������
     * @return �����f�[�^VO
     * @throws HAMException
     */
    public FindMbj49MediaProductionVO getMasterMaintenanceMediaProduction(Mbj49MediaProductionCondition condition) throws HAMException {

        FindMbj49MediaProductionVO vo = new FindMbj49MediaProductionVO();

        if (condition != null) {
            Mbj49MediaProductionDAO dao = Mbj49MediaProductionDAOFactory.createMbj49MediaProductionDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }
    /* 2015/08/31 �����Ɩ��ύX�Ή� HLC S.Fujimoto ADD End */

    /**
     * �S���҃X�v���b�h�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMasterMaintenanceUserSpreadVO getUserSpread(MasterMaintenanceUserSpreadCondition condition) throws HAMException {

        FindMasterMaintenanceUserSpreadVO vo = new FindMasterMaintenanceUserSpreadVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getUserSpreadVO(condition));
        }

        return vo;
    }

    /**
     * �Ԏ팠���X�v���b�h�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMasterMaintenanceCarAuthoritySpreadVO getCarAuthoritySpread(MasterMaintenanceAuthoritySpreadCondition condition) throws HAMException {

        FindMasterMaintenanceCarAuthoritySpreadVO vo = new FindMasterMaintenanceCarAuthoritySpreadVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getCarAuthoritySpreadVO(condition));
        }

        return vo;
    }

    /**
     * �}�̌����X�v���b�h�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMasterMaintenanceMediaAuthoritySpreadVO getMediaAuthoritySpread(MasterMaintenanceAuthoritySpreadCondition condition) throws HAMException {

        FindMasterMaintenanceMediaAuthoritySpreadVO vo = new FindMasterMaintenanceMediaAuthoritySpreadVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getMediaAuthoritySpreadVO(condition));
        }

        return vo;
    }

    /**
     * �Ԏ�S���X�v���b�h�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMasterMaintenanceCarUserSpreadVO getCarUserSpread(MasterMaintenanceCarUserSpreadCondition condition) throws HAMException {

        FindMasterMaintenanceCarUserSpreadVO vo = new FindMasterMaintenanceCarUserSpreadVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getCarUserSpreadVO(condition));
        }

        return vo;
    }

    /**
     * HC���i�X�v���b�h�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMasterMaintenanceHCProductSpreadVO getHCProductSpread(MasterMaintenanceHCProductSpreadCondition condition) throws HAMException {

        FindMasterMaintenanceHCProductSpreadVO vo = new FindMasterMaintenanceHCProductSpreadVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getHCProductSpreadVO(condition));
        }

        return vo;
    }

    /**
     * �@�\����X�v���b�h�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMasterMaintenanceFunctionControlSpreadVO getFunctionControlSpread(MasterMaintenanceFunctionControlSpreadCondition condition) throws HAMException {

        FindMasterMaintenanceFunctionControlSpreadVO vo = new FindMasterMaintenanceFunctionControlSpreadVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getFunctionControlSpreadVO(condition));
        }

        return vo;
    }

    /**
     * �Z�L�����e�B�X�v���b�h�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMasterMaintenanceSecuritySpreadVO getSecuritySpread(MasterMaintenanceSecuritySpreadCondition condition) throws HAMException {

        FindMasterMaintenanceSecuritySpreadVO vo = new FindMasterMaintenanceSecuritySpreadVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getSecuritySpreadVO(condition));
        }

        return vo;
    }

    /**
     * �V�G�}�̃}�X�^�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMasterMaintenanceMEU20MSMZBTVO getMEU20MSMZBT(MasterMaintenanceMEU20MSMZBTCondition condition) throws HAMException {

        FindMasterMaintenanceMEU20MSMZBTVO vo = new FindMasterMaintenanceMEU20MSMZBTVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getMasterMaintenanceMEU20MSMZBTVO(condition));
        }

        return vo;
    }

    /**
     * �o���g�D�W�J�e�[�u�������f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMasterMaintenanceMEU07SIKKRSPRDVO getMasterMaintenanceMEU07SIKKRSPRD(MasterMaintenanceMEU07SIKKRSPRDCondition condition) throws HAMException {

        FindMasterMaintenanceMEU07SIKKRSPRDVO vo = new FindMasterMaintenanceMEU07SIKKRSPRDVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getMasterMaintenanceMEU07SIKKRSPRDVO(condition));
        }

        return vo;
    }

    /**
     * �o���g�D�W�J�e�[�u�������f�[�^VO�擾�i�܂ތ����j
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMasterMaintenanceMEU07SIKKRSPRDVO getMasterMaintenanceMEU07SIKKRSPRDLike(MasterMaintenanceMEU07SIKKRSPRDLikeCondition condition) throws HAMException {

        FindMasterMaintenanceMEU07SIKKRSPRDVO vo = new FindMasterMaintenanceMEU07SIKKRSPRDVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getMasterMaintenanceMEU07SIKKRSPRDVO(condition));
        }

        return vo;
    }

    /**
     * �l���View�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMasterMaintenanceAccUserVO getMasterMaintenanceAccUser(MasterMaintenanceAccUserCondition condition) throws HAMException {

        FindMasterMaintenanceAccUserVO vo = new FindMasterMaintenanceAccUserVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getMasterMaintenanceAccUserVO(condition));
        }

        return vo;
    }

    /**
     * �l���View�����f�[�^VO�擾�i�܂ތ����j
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMasterMaintenanceAccUserVO getMasterMaintenanceAccUserLike(MasterMaintenanceAccUserLikeCondition condition) throws HAMException {

        FindMasterMaintenanceAccUserVO vo = new FindMasterMaintenanceAccUserVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getMasterMaintenanceAccUserVO(condition));
        }

        return vo;
    }

    /**
     * �˗��挟���f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMasterMaintenanceFindContactRequestVO getMasterMaintenanceFindContactRequest(FindContactRequestCondition condition) throws HAMException {

        FindMasterMaintenanceFindContactRequestVO vo = new FindMasterMaintenanceFindContactRequestVO();

        if (condition != null) {
            FindContactRequestDAO dao = FindContactRequestDAOFactory.createFindContactRequestDAO();
            vo.setFindList(dao.selectVO(condition));
        }

        return vo;
    }

    /* 2016/02/17 HDX�Ή� HLC K.Oki ADD Start */
    /**
     * �Ԏ�S����(�f��)�o�^�f�[�^VO�o�^
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceCarUserSozai(RegistMbj52SzTntUserVO vo) throws HAMException {

        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(),Mbj52SzTntUser.TBNAME,Mbj52SzTntUser.PREFIX);

        Mbj52SzTntUserDAO dao = Mbj52SzTntUserDAOFactory.createMbj52SzTntUserDAO();

        //�f�[�^�폜
        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVO(vo.getDeleteList().get(i));
        }

        //�f�[�^�o�^
        if(vo.getInsertList() != null) {
            for(Mbj52SzTntUserVO mbj52VO : vo.getInsertList()) {
                //�V�K�o�^�̏ꍇ
                if(mbj52VO.getUSERSEQ().intValue() == Integer.parseInt(HAMConstants.ZERO))
                {
                    //�ő�l(�S����SEQ�E�\�[�gNo)�i�[�p�ϐ�
                    int MaxUserSeq = 1;
                    int MaxSortNo = 1;

                    //Condition�ݒ�
                    Mbj52SzTntUserCondition mbj52Cond = new Mbj52SzTntUserCondition();
                    mbj52Cond.setDcarcd(mbj52VO.getDCARCD());

                    //�Ԏ킲�Ƃ̒S����SEQ�ƃ\�[�gNo���擾���ݒ�
                    List<Mbj52SzTntUserVO> mbj52Dao = dao.selectVO(mbj52Cond);

                    //�e�[�u���ɍs�����݂���ꍇ
                    if(mbj52Dao.size() > 0) {
                        Mbj52SzTntUserVO UserSeqVo = mbj52Dao.get(Integer.parseInt(HAMConstants.ZERO));
                        Mbj52SzTntUserVO SortNoVo = mbj52Dao.get(Integer.parseInt(HAMConstants.ONE));

                        //�擾�����Ԏ킲�Ƃ̒S����SEQ�ƃ\�[�gNo�̒l���ő�l�ɐݒ�
                        MaxUserSeq = UserSeqVo.getUSERSEQ().intValue() + 1;
                        MaxSortNo = SortNoVo.getSORTNO().intValue() + 1;
                    }

                    //�Ԏ킲�Ƃ̒S����SEQ�ƃ\�[�gNo�̍ő�l�����ꂼ��ݒ�
                    mbj52VO.setUSERSEQ(new BigDecimal(MaxUserSeq));
                    mbj52VO.setSORTNO(new BigDecimal(MaxSortNo));

                    dao.insertVO(mbj52VO);
                }
                //�o�^�ς݂̏ꍇ
                else
                {
                    dao.insertVO(mbj52VO);
                }
            }
        }
    }

    /**
     * �Ԏ�S����(�f��)�o�^�f�[�^VO�o�^(USERID�w��)
     *
     * @param vo �f�[�^VO
     */
    public void registMasterMaintenanceCarUserSozaiUserID(RegistMbj52SzTntUserVO vo) throws HAMException
    {
        if (vo == null) {
            return;
        }

        RegistExclusionDao registExclusionDao = RegistExclusionDaoFactory.createRegistExclusionDao();
        registExclusionDao.checkExclusion(vo.getExclusion(), Mbj52SzTntUser.TBNAME,Mbj52SzTntUser.PREFIX);

        Mbj52SzTntUserDAO dao = Mbj52SzTntUserDAOFactory.createMbj52SzTntUserDAO();

        //�f�[�^�폜
        for (int i = 0 ; (vo.getDeleteList() != null) && (i < vo.getDeleteList().size()) ; i++) {
            dao.deleteVOWhereUserID(vo.getDeleteList().get(i));
        }
    }

    /**
     * �Ԏ�S��(�f��)�X�v���b�h�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMasterMaintenanceCarUserSozaiSpreadVO getCarUserSozaiSpread(MasterMaintenanceCarUserSozaiSpreadCondition condition) throws HAMException {

        FindMasterMaintenanceCarUserSozaiSpreadVO vo = new FindMasterMaintenanceCarUserSozaiSpreadVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getCarUserSozaiSpreadVO(condition));
        }

        return vo;
    }

    /**
     * �Z�L�����e�B�O���[�v���[�U�[(HC/HM)�X�v���b�h�����f�[�^VO�擾
     *
     * @return �����f�[�^VO
     * @param condition ��������
     */
    public FindMasterMaintenanceHCHMSecGrpUserSpreadVO getHCHMSecGrpUserSpread(MasterMaintenanceHCHMSecGrpUserSpreadCondition condition) throws HAMException {

        FindMasterMaintenanceHCHMSecGrpUserSpreadVO vo = new FindMasterMaintenanceHCHMSecGrpUserSpreadVO();

        if (condition != null) {
            MasterMaintenanceDispDao dao = MasterMaintenanceDispDaoFactory.createMasterMaintenanceDispDao();
            vo.setFindList(dao.getHCHMSecGrpUserSpreadVO(condition));
        }

        return vo;
    }
    /* 2016/02/17 HDX�Ή� HLC K.Oki ADD End */

    /**
     * �n��`�F�b�N
     *
     * @param vo �Ώۃf�[�^
     */
    public void checkRegistMasterMaintenanceSeries(RegistMbj04KeiretsuVO vo) throws HAMException {

        if ((vo.getDeleteList() != null) && (vo.getDeleteList().size() > 0)) {
            MasterMaintenanceCheckDao checkDao = MasterMaintenanceCheckDaoFactory.createMasterMaintenanceCheckDao();
            checkDao.checkDeleteMasterMaintenanceSeries(vo.getDeleteList());
        }
    }

    /**
     * ������O���[�v�`�F�b�N
     *
     * @param vo �Ώۃf�[�^
     */
    public void checkRegistMasterMaintenanceDemandGroup(RegistMbj26BillGroupVO vo) throws HAMException {

        if ((vo.getDeleteList() != null) && (vo.getDeleteList().size() > 0)) {
            MasterMaintenanceCheckDao checkDao = MasterMaintenanceCheckDaoFactory.createMasterMaintenanceCheckDao();
            checkDao.checkDeleteMasterMaintenanceDemandGroup(vo.getDeleteList());
        }
    }

    /**
     * HC����`�F�b�N
     *
     * @param vo �Ώۃf�[�^
     */
    public void checkRegistMasterMaintenanceHCSection(RegistMbj06HcBumonVO vo) throws HAMException {

        if ((vo.getDeleteList() != null) && (vo.getDeleteList().size() > 0)) {
            MasterMaintenanceCheckDao checkDao = MasterMaintenanceCheckDaoFactory.createMasterMaintenanceCheckDao();
            checkDao.checkDeleteMasterMaintenanceHCSection(vo.getDeleteList());
        }
    }

    /**
     * �ݒ�ǃ`�F�b�N
     *
     * @return �`�F�b�NResult
     * @param vo �Ώۃf�[�^
     */
    public void checkRegistMasterMaintenanceEstablishmentOffice(RegistMbj29SetteiKykVO vo) throws HAMException {

        if ((vo.getDeleteList() != null) && (vo.getDeleteList().size() > 0)) {
            MasterMaintenanceCheckDao checkDao = MasterMaintenanceCheckDaoFactory.createMasterMaintenanceCheckDao();
            checkDao.checkDeleteMasterMaintenanceEstablishmentOffice(vo.getDeleteList());
        }
    }

    /**
     * ���͒S���`�F�b�N
     *
     * @return �`�F�b�NResult
     * @param vo �Ώۃf�[�^
     */
    public void checkRegistMasterMaintenanceInputUser(RegistMbj30InputTntVO vo) throws HAMException {

        if ((vo.getDeleteList() != null) && (vo.getDeleteList().size() > 0)) {
            MasterMaintenanceCheckDao checkDao = MasterMaintenanceCheckDaoFactory.createMasterMaintenanceCheckDao();
            checkDao.checkDeleteMasterMaintenanceInputUser(vo.getDeleteList());
        }
    }

}
