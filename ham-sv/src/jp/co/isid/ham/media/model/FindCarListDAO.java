package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import jp.co.isid.ham.common.model.CarListVO;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;
import jp.co.isid.ham.integ.tbl.Tbj12Campaign;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;
import jp.co.isid.nj.model.ModelUtils;

/**
 *
 * <P>
 * �L�����y�[���ꗗ�̏��擾DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/30 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
public class FindCarListDAO extends AbstractRdbDao {

    /** �f�[�^�������� */
    private FindCampaignListCondition _cond;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindCarListDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * �v���C�}���L�[��Ԃ��܂�
     *
     * @return String[] �v���C�}���L�[
     */
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * �X�V���t�t�B�[���h��Ԃ��܂�
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * �e�[�u������Ԃ��܂�
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return null;
    }

    /**
     * �e�[�u���񖼂�Ԃ��܂�
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[]{
                Mbj05Car.KEIRETSUCD,
                Mbj05Car.DCARCD,
                Mbj05Car.CARNM,
                Mbj05Car.SORTNO,
                Mbj11CarSec.DCARCD,
                Mbj11CarSec.AUTHORITY
        };
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getSelectSQL() {

        return getCarList();
    }

    /**
     *�쐬�ς� �Ԏ�ꗗ�擾��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    private String getCarList() {

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
        sql.append(" "+ Mbj05Car.TBNAME + ", ");
        sql.append(" "+ Mbj11CarSec.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" "+ Mbj11CarSec.SECTYPE+ " = '0' ");
        sql.append(" AND ");
        sql.append(" "+ Mbj05Car.DISPSTS+ " = '1' ");
        sql.append(" AND ");
        sql.append(" "+ Mbj11CarSec.DCARCD + " = " + Mbj05Car.DCARCD + " ");
        sql.append(" AND ");
        sql.append(" "+ Mbj11CarSec.HAMID + " = '" + _cond.getHamid() + "' ");
        sql.append(" AND ");
        sql.append(" " + Mbj11CarSec.AUTHORITY + " <> '0'" );
        sql.append(" AND ");
        sql.append(" "+ Mbj05Car.DCARCD + " IN ( ");
        sql.append(" SELECT DISTINCT");
        sql.append(" "+ Tbj12Campaign.DCARCD + " ");
        sql.append(" FROM ");
        sql.append(" "+ Tbj12Campaign.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" "+ Tbj12Campaign.PHASE + " = " + _cond.getPhase() + " ");
        sql.append(" ) ");
        sql.append(" ORDER BY ");
        sql.append("  "+ Mbj05Car.SORTNO + "  ");
        sql.append(" ,"+ Mbj05Car.DCARCD + "  ");

        return sql.toString();
    }

    /**
     * �쐬�ςݎԎ�ꗗ�̌������s���܂�
     *
     * @return �Ԏ�ꗗVO���X�g
     * @throws UserException
     *             �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public List<CarListVO> findCarList(FindCampaignListCondition cond) throws HAMException {

        super.setModel(new CarListVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BD-E0002");
        }
    }

    /**
     * Model�̐������s��<br>
     * �������ʂ�VO��KEY���啶���̂��ߕϊ��������s��<br>
     * AbstractRdbDao��createFindedModelInstances���I�[�o�[���C�h<br>
     *
     * @param hashList
     *            List ��������
     * @return List<FindJissiNoCntCondVO> �ϊ���̌�������
     */
    @Override
    protected List<CarListVO> createFindedModelInstances(List hashList) {

        List<CarListVO> list = new ArrayList<CarListVO>();

        if (getModel() instanceof CarListVO) {
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                CarListVO vo = new CarListVO();
                vo.setKEIRETSUCD((String)result.get(Mbj05Car.KEIRETSUCD.toUpperCase()));
                vo.setDCARCD((String)result.get(Mbj05Car.DCARCD.toUpperCase()));
                vo.setCARNM((String)result.get(Mbj05Car.CARNM.toUpperCase()));
                vo.setSORTNO((BigDecimal)result.get(Mbj05Car.SORTNO.toUpperCase()));
                vo.setAUTHORITY((String)result.get(Mbj11CarSec.AUTHORITY.toUpperCase()));

                // �������ʒ���̏�Ԃɂ���
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        }

        return list;
    }

}
